using UnityEngine;

public class Tuto : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private PickUpItem pickUpScript;

    [SerializeField] private GameObject UiTutoI;

    private void Start()
    {
        UiTutoI.SetActive(false);
    }

    private void Update()
    {
        if (pickUpScript.isdestroyed)
        {
            UiTutoI.SetActive(true);
        }

        if (inventory.isOpen)
        {
            pickUpScript.isdestroyed = false;
            UiTutoI.SetActive(false);
        }
    }
}
