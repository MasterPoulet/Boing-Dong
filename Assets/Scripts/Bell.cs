using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public bool peutOuvrir;
    public Inventory inventory;
    public ItemData itemData;


    public void OnTriggerEnter(Collider other)
    {
        peutOuvrir = other.CompareTag("Player");
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            peutOuvrir = false;
        }
    }
}
