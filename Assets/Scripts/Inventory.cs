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


    [Header("Action Panel References")]

    [SerializeField]
    private GameObject actionPanel;

    [SerializeField]
    private GameObject UseItemButton;

    [SerializeField]
    private GameObject InspectItemButton;

    [SerializeField]
    private GameObject DeleteItemButton;

    private ItemData itemCurrentlySelected;

    [SerializeField]
    private Sprite emptySlotVisual;

    public static Inventory instance;

    private bool isOpen = false;

    private void Awake()
    {
        instance = this;
    }

    // Liste de ce qu'il y a dans l'inventaire + comment les ajouter
    public List<ItemData> content = new List<ItemData>();

    public void AddItem(ItemData item)
    {
        content.Add(item);
    }

    private void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        isOpen = true;
    }

    // Permet de fermer l'inventaire lorsque l'on clique sur la croix
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        actionPanel.SetActive(false);
        ToolTipSystem.instance.Hide();
        isOpen = false;
    }

    private void RefreshContent()
    {
        // On vide tous les slots / visuels
        for (int i = 0; i < inventorySlotsParent.childCount; i++)
        {
            Slots currentSlot = inventorySlotsParent.GetChild(i).GetComponent<Slots>();

            currentSlot.item = null;
            currentSlot.itemVisual.sprite = emptySlotVisual;
        }

        // On affiche les objets que le joueur a sur lui
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

    public void OpenActionPanel(ItemData item, Vector3 slotPosition)
    {
        itemCurrentlySelected = item;

        if(item ==  null)
        {
            actionPanel.SetActive(false);
            return;
        }

        switch(item.itemType)
        {
            case ItemType.Consumable:
                UseItemButton.SetActive(true);
                InspectItemButton.SetActive(false);
                break;
            case ItemType.Key:
                UseItemButton.SetActive(true);
                InspectItemButton.SetActive(true);
                break;
            case ItemType.Weapon:
                UseItemButton.SetActive(true);
                InspectItemButton.SetActive(false);
                break;
            case ItemType.Ammo:
                UseItemButton.SetActive(true);
                InspectItemButton.SetActive(false);
                break;
        }

        actionPanel.transform.position = slotPosition;
        actionPanel.SetActive(true);
    }

    public void  CloseActionPanel()
    {
        actionPanel.SetActive(false);
        itemCurrentlySelected = null;
    }

    public void UseActionButton()
    {
        print(itemCurrentlySelected.name + " a été utilisé");
        CloseActionPanel();
    }

    public void InspectActionButton()
    {
        print(itemCurrentlySelected.name + " a été inspecté");
        CloseActionPanel();
    }

    public void DeleteActionButton()
    {
        content.Remove(itemCurrentlySelected);
        RefreshContent();
        CloseActionPanel();
    }

    private void Update()
    {
        // Permet d'ouvrir/fermer l'inventaire lorsque I est appuyé
        if (Input.GetKeyUp(KeyCode.I))
        {
            RefreshContent();
            if (isOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
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
