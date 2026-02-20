using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/New Item")]
public class ItemData : ScriptableObject
{
    public string nameItem;
    public Sprite visual;
    public GameObject prefab;
}
