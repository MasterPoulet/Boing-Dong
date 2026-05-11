using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Bell : MonoBehaviour
{
    private bool peutOuvrir;
    public Inventory inventory;
    public ItemData itemData;


    private void OnTriggerEnter(Collider other)
    {
        peutOuvrir = other.CompareTag("Player");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            peutOuvrir = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && peutOuvrir)
        {
            inventory.OpenInventory();
        }

        if (inventory.usePressed && peutOuvrir)
        {
            print("use is pressed btw");
        }
    }
}
