using UnityEngine;

public class GreenDoor : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Tuto tuto;

    [SerializeField] private GameObject greenDoorClosed;
    [SerializeField] private GameObject greenDoorOpen;

   

    private void Start()
    {
        greenDoorClosed.SetActive(true);
        greenDoorOpen.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        inventory.greenDoor = this;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.greenDoor = null;
        }
    }

    public void OpenGreenDoor()
    {
        greenDoorClosed.SetActive(false);
        greenDoorOpen.SetActive(true);
    }
}
