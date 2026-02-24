using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemData item;
    public Image itemVisual;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            ToolTipSystem.instance.Show(item.descriptionItem, item.nameItem);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.instance.Hide();
    }

    public void ClickOnSlot()
    {
        Inventory.instance.OpenActionPanel(item, transform.position);
    }
}
