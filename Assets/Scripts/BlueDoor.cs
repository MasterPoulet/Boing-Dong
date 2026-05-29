using UnityEngine;

public class BluenDoor : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private GameObject blueDoorClosed;

   

    private void Start()
    {
        blueDoorClosed.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        inventory.blueDoor = this;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.greenDoor = null;
        }
    }

    public void OpenBlueDoor()
    {
        blueDoorClosed.SetActive(false);
    }
}
