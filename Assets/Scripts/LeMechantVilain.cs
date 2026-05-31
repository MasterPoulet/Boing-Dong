using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.VisualScripting;

public class LeMechantVilain : MonoBehaviour
{
    private enum State { Patrolling, ChasingPlayer };
    private State currentState = State.Patrolling;

    public float moveSpeed = 2f;
    public Transform[] patrolPoints;
    public float pauseDuration = 2f;

    public float radius = 10f;
    public float angle = 60f;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public GameObject playerRef;
    public bool canSeePlayer;

    private NavMeshAgent agent;
    private Transform targetPoint;
    private bool isPausing = false;
    private bool isChasingPlayer = false;

    private Animator animator;

    [SerializeField] private GameObject LightRed;
    public AudioSource boing;
    public AudioSource evilBoing;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        playerRef = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        LightRed.SetActive(false);

        if (patrolPoints.Length > 0)
        {
            ChooseRandomPatrolPoint();
            agent.SetDestination(targetPoint.position);
        }

        StartCoroutine(FOVRoutine());
    }

    private void Update()
    {
        //Rescue si l'agent sort du NavMesh
        if (!agent.isOnNavMesh)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(transform.position, out hit, 5f, NavMesh.AllAreas))
                agent.Warp(hit.position);
            return;
        }

        HandleState();

        if (!isPausing && !isChasingPlayer && !agent.pathPending && agent.remainingDistance < 1f)
        {
            currentState = State.Patrolling;
            if (!isPausing)
                StartCoroutine(PauseAndPatrol());
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;

                    if (currentState != State.ChasingPlayer)
                    {
                        isChasingPlayer = true;
                        currentState = State.ChasingPlayer;
                        LightRed.SetActive(true);
                    }
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else
        {
            canSeePlayer = false;
        }
    }

    private void HandleState()
    {
        switch (currentState)
        {
            case State.Patrolling:
                break;

            case State.ChasingPlayer:
                ChasingPlayer();
                break;
        }
    }

    private IEnumerator PauseAndPatrol()
    {
        isPausing = true;
        animator.SetFloat("Speed", 0);
        boing.Stop();

        yield return new WaitForSeconds(pauseDuration);

        ChooseRandomPatrolPoint();
        agent.SetDestination(targetPoint.position);
        animator.SetFloat("Speed", 1);
        boing.Play();
        evilBoing.Stop();

        LightRed.SetActive(false);
        isPausing = false;
    }

    private void ChooseRandomPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, patrolPoints.Length);
            targetPoint = patrolPoints[randomIndex];
        }
    }

    private void ChasingPlayer()
    {
        if (canSeePlayer)
        {
            agent.SetDestination(playerRef.transform.position);
            animator.SetFloat("Speed", 1);
            if (!evilBoing.isPlaying)
            {
                evilBoing.Play();
            }
            boing.Stop();
        }

        if (!agent.pathPending && agent.remainingDistance < 1.5f && !canSeePlayer)
        {
            isChasingPlayer = false;
            currentState = State.Patrolling;
            animator.SetFloat("Speed", 1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (patrolPoints != null && patrolPoints.Length > 0)
        {
            Gizmos.color = Color.blue;
            foreach (Transform patrolPoint in patrolPoints)
            {
                if (patrolPoint != null)
                    Gizmos.DrawSphere(patrolPoint.position, 0.3f);
            }
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.green;
        Vector3 leftBoundary = Quaternion.Euler(0, -angle / 2, 0) * transform.forward * radius;
        Vector3 rightBoundary = Quaternion.Euler(0, angle / 2, 0) * transform.forward * radius;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}