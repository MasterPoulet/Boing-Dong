using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Inventory inventory;

    private GameObject currentItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Item détecté devant le joueur");
            currentItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            currentItem = null;
        }
    }

    private void Update()
    {
        if (currentItem != null && Input.GetKeyDown(KeyCode.E))
        {
            Item itemComponent = currentItem.GetComponent<Item>();

            if (itemComponent != null)
            {
                inventory.content.Add(itemComponent.item);
                Destroy(currentItem);
                currentItem = null;
            }
        }
    }
}