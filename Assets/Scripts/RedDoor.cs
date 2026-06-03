using UnityEngine;

public class RedDoor : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Tuto tuto;

    [SerializeField] private GameObject redDoorClosed;
    [SerializeField] private GameObject redDoorOpen;

   

    private void Start()
    {
        redDoorClosed.SetActive(true);
        redDoorOpen.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        inventory.redDoor = this;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.greenDoor = null;
        }
    }

    public void OpenRedDoor()
    {
        redDoorClosed.SetActive(false);
        redDoorOpen.SetActive(true);
    }
}
