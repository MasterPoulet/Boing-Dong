using NUnit.Framework;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject
{
    public string nameItem;
    public string descriptionItem;
    public Sprite visual;
    public GameObject prefab;
    public bool stackable;
    public int ID;

    public ItemType itemType;
}

public enum ItemType
{
    Consumable,
    Egg,
    Key,
}