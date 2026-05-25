using UnityEngine;
using System.Collections;

public class SocleSciFi : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés
    private const int maxStepEgg = 5;

    public bool scifiFull = false;

    // Les dialogues
    public GameObject dialogueScifi1;
    public GameObject dialogueScifi2;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    private bool played9 = false;
    private bool played10 = false;

    private void Start()
    {
        dialogueScifi1.SetActive(false);
        dialogueScifi2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            EggCount++;
        }

        // Vérifier si on atteint le quota demandé
        if (EggCount == maxStepEgg)
        {
            ScifiFull();
        }
    }

    public void ScifiFull()
    {
        Debug.Log("SciFi est plein");
        scifiFull = true;
        DialogueScifi1();
        StartCoroutine(Attendre5secondes());
    }

    IEnumerator Attendre5secondes()
    {
        yield return new WaitForSeconds(5f);

        DialogueScifi2();
    }

    private void DialogueScifi1()
    {
        dialogueScifi1.SetActive(true);
        if (!played9)
        {
            soundDialogue1.Play();
            played9 = true;
        }
    }

    private void DialogueScifi2()
    {
        dialogueScifi2.SetActive(true);
        if (!played10)
        {
            soundDialogue2.Play();
            played10 = true;
        }
    }
}
