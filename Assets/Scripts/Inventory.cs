using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public GameObject inventoryPanel;

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

    public bool isOpen = false;

    public Bell bell;

    // flashlight
    public bool flashLightUsed = false;
    [SerializeField]
    private GameObject lightFL;

    // map
    public bool mapUsed = false;

    // TUTO
    public Tuto tuto;

    // ObjetsClés
    public ChildDoor childDoor;
    public GreenDoor greenDoor;
    public BluenDoor blueDoor;
    public RedDoor redDoor;

    // Sons
    public AudioSource buttonSelected;
    [SerializeField] private AudioSource flashlightOn;
    [SerializeField] private AudioSource flashlightOff;
    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource ladder;

    [SerializeField] private Map map;
    [SerializeField] private Echelle echelle;

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

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        isOpen = true;
        buttonSelected.Play();
    }

    // Permet de fermer l'inventaire lorsque l'on clique sur la croix
    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
        actionPanel.SetActive(false);
        ToolTipSystem.instance.Hide();
        isOpen = false;
        tuto.CloseTutoInventory();
        map.FermetureMap();
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
            case ItemType.Utilitaire:
                UseItemButton.SetActive(true);
                InspectItemButton.SetActive(true);
                DeleteItemButton.SetActive(false);
                break;
            case ItemType.Egg:
                UseItemButton.SetActive(true);
                InspectItemButton.SetActive(true);
                DeleteItemButton.SetActive(false);
                break;
            case ItemType.Key:
                UseItemButton.SetActive(true);
                InspectItemButton.SetActive(true);
                DeleteItemButton.SetActive(false);
                break;
            case ItemType.Yuselegg:
                UseItemButton.SetActive(false);
                InspectItemButton.SetActive(true);
                DeleteItemButton.SetActive(false);
                break;
        }

        actionPanel.transform.position = slotPosition;
        actionPanel.SetActive(true);
        buttonSelected.Play();
    }

    public void  CloseActionPanel()
    {
        actionPanel.SetActive(false);
        itemCurrentlySelected = null;
        buttonSelected.Play();
    }

    public void UseActionButton()
    {
        if (bell != null && itemCurrentlySelected.prefab.CompareTag("Egg"))
        {
            print(itemCurrentlySelected.name + " a été utilisé");
            bell.PlacePrefab(itemCurrentlySelected);
            content.Remove(itemCurrentlySelected);
        }

        if (itemCurrentlySelected.prefab.CompareTag("FlashLight"))
        {
            if (flashLightUsed == false)
            {
                lightFL.SetActive(true);
                flashLightUsed = true;
                flashlightOn.Play();
            }

            else
            {
                lightFL.SetActive(false);
                flashLightUsed = false;
                flashlightOff.Play();
            }
        }

        if (childDoor != null && itemCurrentlySelected.prefab.CompareTag("KeyChild"))
        {
            print(itemCurrentlySelected.name + " a été utilisé");
            childDoor.OpenChildDoor();
            doorOpen.Play();
            content.Remove(itemCurrentlySelected);
        }

        if (greenDoor != null && itemCurrentlySelected.prefab.CompareTag("KeyGreen"))
        {
            print(itemCurrentlySelected.name + " a été utilisé");
            greenDoor.OpenGreenDoor();
            doorOpen.Play();
            content.Remove(itemCurrentlySelected);
        }

        if (blueDoor != null && itemCurrentlySelected.prefab.CompareTag("KeyBlue"))
        {
            print(itemCurrentlySelected.name + " a été utilisé");
            blueDoor.OpenBlueDoor();
            doorOpen.Play();
            content.Remove(itemCurrentlySelected);
        }

        if (redDoor != null && itemCurrentlySelected.prefab.CompareTag("KeyRed"))
        {
            print(itemCurrentlySelected.name + " a été utilisé");
            redDoor.OpenRedDoor();
            doorOpen.Play();
            content.Remove(itemCurrentlySelected);
        }

        if (itemCurrentlySelected.prefab.CompareTag("Map"))
        {
            map.OuvertureMap();
        }

        if (echelle != null && itemCurrentlySelected.prefab.CompareTag("Echelle"))
        {
            print(itemCurrentlySelected.name + " a été utilisé");
            echelle.ActiveEchelle();
            ladder.Play();
            content.Remove(itemCurrentlySelected);
        }

        RefreshContent();
        CloseActionPanel();
    }

    public void InspectActionButton()
    {
        print(itemCurrentlySelected.name + " a été inspecté");
        if (itemCurrentlySelected != null)
        {
            ToolTipSystem.instance.Show(itemCurrentlySelected.descriptionItem, itemCurrentlySelected.nameItem);
        }
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
