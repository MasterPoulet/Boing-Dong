using UnityEngine;
using System.Collections;

public class SocleFlower : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés
    private const int maxStepEgg = 5;

    public bool flowerFull = false;

    // Les dialogues
    public GameObject dialogueFlower1;
    public GameObject dialogueFlower2;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    private bool played5 = false;
    private bool played6 = false;

    private void Start()
    {
        dialogueFlower1.SetActive(false);
        dialogueFlower2.SetActive(false);
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
            FlowerFull();
        }
    }

    public void FlowerFull()
    {
        Debug.Log("Flower est plein");
        flowerFull = true;
        DialogueFlower1();
        StartCoroutine(Attendre5secondes());
    }

    IEnumerator Attendre5secondes()
    {
        yield return new WaitForSeconds(5f);

        DialogueFlower2();
    }

    private void DialogueFlower1()
    {
        dialogueFlower1.SetActive(true);
        if (!played5)
        {
            soundDialogue1.Play();
            played5 = true;
        }
    }

    private void DialogueFlower2()
    {
        dialogueFlower2.SetActive(true);
        if (!played6)
        {
            soundDialogue2.Play();
            played6 = true;
        }
    }
}
