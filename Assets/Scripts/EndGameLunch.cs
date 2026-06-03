using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGameLunch : MonoBehaviour
{
    [SerializeField] private GameObject E;
    public bool here = false;

    private void Start()
    {
        E.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(true);
            here = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.SetActive(false);
            here = false;
        }
    }

    private void Update()
    {
        if (here && Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
