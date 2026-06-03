using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameLunch : MonoBehaviour
{

    [SerializeField] private GameObject Menu;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("EndGame");
        }
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
