using UnityEngine;

public class Tuto : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PickUpItem pickUpScript;

    [SerializeField] private GameObject UiTutoI; 
    [SerializeField] private GameObject UiTutoInventory;
    private bool tutoInventCanOpen = true;

    [SerializeField] private GameObject UiObjetsCles;
    [SerializeField] private GameObject UiIntro;

    [SerializeField] private AudioSource ClocheIntro;

    public MonoBehaviour CameraScript;

    [SerializeField] private GameObject point;


    private void Start()
    {
        UiTutoI.SetActive(false);
        UiTutoInventory.SetActive(false);
        UiObjetsCles.SetActive(false);
        UiIntro.SetActive(true);
    }

    private void Update()
    {
        if (!ClocheIntro.isPlaying)
        {
            UiIntro.SetActive(false);
            point.SetActive(true);
        }


        if (pickUpScript.isdestroyed)
        {
            UiTutoI.SetActive(true);
        }

        if (inventory.isOpen && tutoInventCanOpen)
        {
            pickUpScript.isdestroyed = false;
            UiTutoI.SetActive(false);
            UiTutoInventory.SetActive(true);
        }
    }

    public void CloseTutoInventory()
    {
        UiTutoInventory.SetActive(false);
        tutoInventCanOpen = false;
        inventory.buttonSelected.Play();
    }

    public void OpenTutoObjCles()
    {
        UiObjetsCles.SetActive(true);
    }

    public void CloseTutoObjCles()
    {
        UiObjetsCles.SetActive(false);
    }
}
