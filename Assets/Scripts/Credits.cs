using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public float scrollspeed = 40f;

    private RectTransform rectTransform;

    private GameObject Menu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, scrollspeed * Time.deltaTime);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}


