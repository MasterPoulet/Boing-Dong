using UnityEngine;
using System.Collections;

public class SocleGalaxy : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés
    private const int maxStepEgg = 5;

    public bool galaxyFull = false;

    // Les dialogues
    public GameObject dialogueGalaxy1;
    public GameObject dialogueGalaxy2;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    private bool played13 = false;
    private bool played14 = false;

    private void Start()
    {
        dialogueGalaxy1.SetActive(false);
        dialogueGalaxy2.SetActive(false);
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
            GalaxyFull();
        }
    }

    public void GalaxyFull()
    {
        Debug.Log("Galaxy est plein");
        galaxyFull = true;
        DialogueGalaxy1();
        StartCoroutine(Attendre5secondes());
    }

    IEnumerator Attendre5secondes()
    {
        yield return new WaitForSeconds(5f);

        DialogueGalaxy2();
    }

    private void DialogueGalaxy1()
    {
        dialogueGalaxy1.SetActive(true);
        if (!played13)
        {
            soundDialogue1.Play();
            played13 = true;
        }
    }

    private void DialogueGalaxy2()
    {
        dialogueGalaxy2.SetActive(true);
        if (!played14)
        {
            soundDialogue2.Play();
            played14 = true;
        }
    }
}

