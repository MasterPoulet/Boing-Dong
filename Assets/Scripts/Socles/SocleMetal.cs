using UnityEngine;
using System.Collections;

public class SocleMetal : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés
    private const int maxStepEgg = 5;

    public bool metalFull = false;

    // Les dialogues
    public GameObject dialogueMetal1;
    public GameObject dialogueMetal2;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    private bool played11 = false;
    private bool played12 = false;

    private void Start()
    {
        dialogueMetal1.SetActive(false);
        dialogueMetal2.SetActive(false);
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
            MetalFull();
        }
    }

    public void MetalFull()
    {
        Debug.Log("Metal est plein");
        metalFull = true;
        DialogueMetal1();
        StartCoroutine(Attendre5secondes());
    }

    IEnumerator Attendre5secondes()
    {
        yield return new WaitForSeconds(5f);

        DialogueMetal2();
    }

    private void DialogueMetal1()
    {
        dialogueMetal1.SetActive(true);
        if (!played11)
        {
            soundDialogue1.Play();
            played11 = true;
        }
    }

    private void DialogueMetal2()
    {
        dialogueMetal2.SetActive(true);
        if (!played12)
        {
            soundDialogue2.Play();
            played12 = true;
        }
    }
}
