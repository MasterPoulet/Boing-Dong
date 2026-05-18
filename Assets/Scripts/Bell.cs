using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public Inventory inventory;
    public ItemData itemData;
    public Transform[] positionEgg;



    public void OnTriggerEnter(Collider other)
    {
        inventory.bell = this;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.bell = null;
        }
    }

    public void PlacePrefab(ItemData item)
    {
        item.prefab.transform.position = positionEgg[item.ID].position;
    }
}
