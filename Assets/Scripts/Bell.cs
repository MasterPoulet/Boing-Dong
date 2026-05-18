using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public bool peutOuvrir;
    public Inventory inventory;
    public ItemData itemData;
    public Transform[] position;



    public void OnTriggerEnter(Collider other)
    {
        peutOuvrir = other.CompareTag("Player");
        inventory.bell = this;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            peutOuvrir = false;
            inventory.bell = null;
        }
    }

    public void PlacePrefab(ItemData item)
    {
        item.prefab.transform.position = position[item.ID].position;
    }
}
