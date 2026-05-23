using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Inventory inventory;
    public Tuto tuto;

    private GameObject currentItem;

    public bool isdestroyed = false;

    [SerializeField] private AudioSource pickUpItem;

    // Regarde si le gameobject a le tag Item et s'il est dans le collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            Debug.Log("Item détecté devant le joueur");
            currentItem = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            currentItem = null;
        }
    }

    private void OpenUItutoI()
    {
        isdestroyed = true;
    }

    private void OpenUItutoOC()
    {
        tuto.OpenTutoObjCles();
    }

    // Si le joueur appuie sur E, cela ramasse/rajoute l'item à l'inventaire sauf s'il n'y a plus de places
    public void Update()
    {
        if (currentItem != null && Input.GetKeyDown(KeyCode.E) && !inventory.IsFull())
        {
            pickUpItem.Play();

            Item itemComponent = currentItem.GetComponent<Item>();

            if (currentItem.CompareTag("FlashLight"))
            {
                OpenUItutoI();
            }

            if (currentItem.CompareTag("KeyChild"))
            {
                OpenUItutoOC();
            }

            if (itemComponent != null)
            {
                itemComponent.item.prefab = currentItem;
                inventory.content.Add(itemComponent.item);
                currentItem.transform.position = new Vector3(33, 0, 10); // téléporte l'objet hors map
                currentItem.layer = LayerMask.NameToLayer("Default"); // permet à ce que le joueur ne puisse pas reprendre l'objet une fois utilisé
                currentItem = null;
            }
        }
    }
}