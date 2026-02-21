using UnityEngine;
using UnityEngine.UI;


public class ToolTip : MonoBehaviour
{
    [SerializeField]
    private Text headerField;
    [SerializeField]
    private Text contentField;


    public void SetText(string content, string header = "")
    {
        if (header == "")
        {
            headerField.gameObject.SetActive(false);
        }

        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;
    }
}
