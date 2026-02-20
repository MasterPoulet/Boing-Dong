using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Inventory inventory;

    private GameObject currentItem;


    // Regarde si le gameobject a le tag Item et s'il est dans le collider
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

    // Si le joueur appuie sur E, cela ramasse/rajoute l'item à l'inventaire sauf s'il n'y a plus de places
    private void Update()
    {
        if (currentItem != null && Input.GetKeyDown(KeyCode.E) && !inventory.IsFull())
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