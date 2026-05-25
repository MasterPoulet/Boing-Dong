using UnityEngine;
using System.Collections;

public class SocleNature : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés
    private const int maxStepEgg = 5;

    public bool natureFull = false;

    // Les dialogues
    public GameObject dialogueNature1;
    public GameObject dialogueNature2;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    private bool played7 = false;
    private bool played8 = false;

    private void Start()
    {
        dialogueNature1.SetActive(false);
        dialogueNature2.SetActive(false);
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
            NatureFull();
        }
    }

    public void NatureFull()
    {
        Debug.Log("Nature est plein");
        natureFull = true;
        DialogueNature1();
        StartCoroutine(Attendre5secondes());
    }

    IEnumerator Attendre5secondes()
    {
        yield return new WaitForSeconds(5f);

        DialogueNature2();
    }

    private void DialogueNature1()
    {
        dialogueNature1.SetActive(true);
        if (!played7)
        {
            soundDialogue1.Play();
            played7 = true;
        }
    }

    private void DialogueNature2()
    {
        dialogueNature2.SetActive(true);
        if (!played8)
        {
            soundDialogue2.Play();
            played8 = true;
        }
    }
}
