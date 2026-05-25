using System.Collections;
using UnityEngine;

public class SocleEaster : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés
    private const int maxStepEgg = 5;

    public bool easterFull = false;

    // Les dialogues
    public GameObject dialogueEaster1;
    public GameObject dialogueEaster2;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    private bool played3 = false;
    private bool played4 = false;

    private void Start()
    {
        dialogueEaster1.SetActive(false);
        dialogueEaster2.SetActive(false);
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
            EasterFull();
        }
    }

    public void EasterFull()
    {
        Debug.Log("Easter est plein");
        easterFull = true;
        DialogueEaster1();
        StartCoroutine(Attendre5secondes());
    }

    IEnumerator Attendre5secondes()
    {
        yield return new WaitForSeconds(5f);

        DialogueEaster2();
    }

    private void DialogueEaster1()
    {
        dialogueEaster1.SetActive(true);
        if (!played3)
        {
            soundDialogue1.Play();
            played3 = true;
        }
    }

    private void DialogueEaster2()
    {
        dialogueEaster2.SetActive(true);
        if (!played4)
        {
            soundDialogue2.Play();
            played4 = true;
        }
    }
}
