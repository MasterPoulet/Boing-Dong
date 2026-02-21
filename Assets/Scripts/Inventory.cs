using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;

    public MonoBehaviour CameraScript;

    [SerializeField]
    private Transform inventorySlotsParent;

    const int InventorySize = 12; // Le nombre de slots max d'ans l'inventaire. ATTENTION ! à la variable const


    // Liste de ce qu'il y a dans l'inventaire + comment les ajouter
    public List<ItemData> content = new List<ItemData>();

    public void AddItem(ItemData item)
    {
        content.Add(item);
    }

    // Permet de fermer l'inventaire lorsque l'on clique sur la croix
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }

    private void RefreshContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            Slots currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slots>();

            currentSlot.item = content[i];
            currentSlot.itemVisual. sprite = content[i].visual;
        }
    }

    public bool IsFull()
    {
        return InventorySize == content.Count;
    }

    private void Update()
    {
        // Permet d'ouvrir/fermer l'inventaire lorsque I est appuyé
        if (Input.GetKeyUp(KeyCode.I))
        {
            RefreshContent();
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        // Permet d'afficher la souris lorsque l'inventaire est affiché
        if (inventoryPanel.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CameraScript.enabled = false; // bloque la camera
            Cursor.lockState = CursorLockMode.Confined; // permet que la souris ne sorte pas de la fenêtre de jeu
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CameraScript.enabled = true; // débloque la camera
        }

    }
}
