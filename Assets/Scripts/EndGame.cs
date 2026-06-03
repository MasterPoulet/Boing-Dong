using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Text;
    [SerializeField] private GameObject TextMerci;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined; // permet que la souris ne sorte pas de la fenêtre de jeu
    }

    public void GoMenu()
    {
        Menu.SetActive(false);
        Text.SetActive(false);
        StartCoroutine(Merci());
        TextMerci.SetActive(true);
    }

    private IEnumerator Merci()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Credits");
    }
}
