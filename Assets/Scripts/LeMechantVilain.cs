using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.EventSystems;
using System.Runtime.CompilerServices;

public class LeMechantVilain : MonoBehaviour
{
    private enum State { Patrolling, ChasingPlayer };
    private State currentState = State.Patrolling;

    private bool canSwitch = true;
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
    private bool isChasingSong = false;

    private Animator animator;

    [SerializeField] private GameObject LightRed;

    // public AudioSource boing;
    /// <summary>
    /// public AudioSource evilBoing;
    /// </summary>

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        playerRef = GameObject.FindGameObjectWithTag("Player");

        if (patrolPoints.Length > 0)
        {
            ChooseRandomPatrolPoint();
        }

        animator = GetComponent<Animator>();

        LightRed.SetActive(false);
    }

    private void Update()
    {
        SwitchState();

        if (!isPausing && !isChasingPlayer && !agent.pathPending && agent.remainingDistance < 1f)
        {
            canSwitch = true;
            currentState = State.Patrolling;
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        animator.SetFloat("Speed", 0);
        // boing.Stop();

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
                    canSwitch = true;
                    currentState = State.ChasingPlayer;
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

    private IEnumerator PauseAndPatrol()
    {
        isPausing = true;

        yield return new WaitForSeconds(pauseDuration);

        ChooseRandomPatrolPoint();
        agent.SetDestination(targetPoint.position);

        animator.SetFloat("Speed", 1);

        isPausing = false;

        LightRed.SetActive(false);
        // boing.Play();
    }

    private void ChooseRandomPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, patrolPoints.Length);
            targetPoint = patrolPoints[randomIndex];
            Debug.Log(targetPoint);
        }
    }

    private void ChasingPlayer()
    {
        if (canSeePlayer)
        {
            Debug.Log("Tiger");
            isChasingPlayer = true;
            agent.SetDestination(playerRef.transform.position);
            animator.SetFloat("Speed", 1);
            LightRed.SetActive(true);
        }

        if (!agent.pathPending && agent.remainingDistance < 20f)
        {
            Debug.Log("Rawr");
            isChasingPlayer = false;
            canSwitch = true;
            currentState = State.Patrolling;
            animator.SetFloat("Speed", 1);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (patrolPoints.Length > 0)
        {
            Gizmos.color = Color.blue;
            foreach (Transform patrolPoint in patrolPoints)
            {
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

    void SwitchState()
    {
        if (canSwitch)
        {
            switch (currentState)
            {
                case State.Patrolling:
                    StartCoroutine(FOVRoutine());
                    StartCoroutine(PauseAndPatrol());
                    break;
                case State.ChasingPlayer:
                    StartCoroutine(FOVRoutine());
                    ChasingPlayer();
                    break;
            }
            canSwitch = false;
        }
        Debug.Log(canSwitch);
    }
}