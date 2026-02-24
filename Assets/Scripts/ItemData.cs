using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject
{
    public string nameItem;
    public string descriptionItem;
    public Sprite visual;
    public GameObject prefab;
    public bool stackable;

    public ItemType itemType;
}

public enum ItemType
{
    Consumable,
    Key,
    Weapon,
    Ammo,
}