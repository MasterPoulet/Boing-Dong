using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;

    [SerializeField] private GameObject DialogueBellEnter;
    [SerializeField] private GameObject DialogueBellExit;

    private bool played15 = false;
    private bool played16 = false;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    [SerializeField] private AudioSource looser;

    private void Start()
    {
        DialogueBellEnter.SetActive(false);
        DialogueBellExit.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController cc = other.GetComponent<CharacterController>();

        if (cc != null)
        {
            cc.enabled = false;
            other.transform.position = playerPos.position;
            cc.enabled = true;
            looser.Play();
            StartCoroutine(Attendre2secondes());
        }

        IEnumerator Attendre2secondes()
        {
            yield return new WaitForSeconds(2f);

            DialogueBell1();
            StartCoroutine(Attendre3secondes());
        }

        IEnumerator Attendre3secondes()
        {
            yield return new WaitForSeconds(3f);

            DialoqueBell2();
        }
    }

    private void DialogueBell1()
    {
        DialogueBellEnter.SetActive(true);
        if (!played15)
        {
            soundDialogue1.Play();
            played15 = true;
        }
    }

    private void DialoqueBell2() 
    {
        DialogueBellExit.SetActive(true);
        if (!played16)
        {
            soundDialogue2.Play();
            played16 = true;
        }
    }
}
