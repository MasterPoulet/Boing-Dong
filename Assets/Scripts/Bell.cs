using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Bell : MonoBehaviour
{
    // Egg system
    public Inventory inventory;
    public ItemData itemData;
    public Transform[] positionEgg;

    // Apparaitre / Disparaitre
    [SerializeField] private GameObject goldWall; //Les murs
    [SerializeField] private GameObject egg1;
    [SerializeField] private GameObject egg2;
    [SerializeField] private GameObject egg3;
    [SerializeField] private GameObject egg4;
    [SerializeField] private GameObject lapinou; //L'ennemis
    [SerializeField] private GameObject RedCage;
    public GameObject sprintTuto; // Le collider sprint
    public GameObject dialogue1Enter; // Les dialogues
    public GameObject dialogue1Exit;
    private bool bulleAffiche1 = false;
    private bool bulleAffiche2 = false;

    //Audio
    [SerializeField] private AudioSource soundDialogue1;
    [SerializeField] private AudioSource soundDialogue2;
    private bool played1 = false;
    private bool played2 = false;

    private void Start()
    {
        dialogue1Enter.SetActive(false);
        dialogue1Exit.SetActive(false);
        sprintTuto.SetActive(false);
        lapinou.SetActive(false);
        egg1.SetActive(false);
        egg2.SetActive(false);
        egg3.SetActive(false);
        egg4.SetActive(false);
        RedCage.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.bell = this;
            Destroy(goldWall);
            DialogueEnter1();
            egg1.SetActive(true);
            egg2.SetActive(true);
            egg3.SetActive(true);
            egg4.SetActive(true);
            RedCage.SetActive(true);

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.bell = null;
            DialogueExit1();
            sprintTuto.SetActive(true);
            lapinou.SetActive(true);

        }

    }

    public void PlacePrefab(ItemData item)
    {
        item.prefab.transform.position = positionEgg[item.ID].position;
    }

    private void DialogueEnter1()
    {
        if (!bulleAffiche1)
        {
            dialogue1Enter.SetActive(true);
            bulleAffiche1 = true;
        }

        if (!played1)
        {
            soundDialogue1.Play();
            played1 = true;
        }
    }

    private void DialogueExit1()
    {
        if (!bulleAffiche2)
        {
            dialogue1Exit.SetActive(true);
            bulleAffiche2 = true;
        }

        if (!played2)
        {
            soundDialogue2.Play();
            played2 = true;
        }
    }
}
