using UnityEngine;

public class ChildDoor : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private GameObject childDoorClosed;
    [SerializeField] private GameObject childDoorOpen;

   

    private void Start()
    {
        childDoorClosed.SetActive(true);
        childDoorOpen.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        inventory.childDoor = this;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.childDoor = null;
        }
    }

    public void OpenChildDoor()
    {
        childDoorClosed.SetActive(false);
        childDoorOpen.SetActive(true);
    }
}
