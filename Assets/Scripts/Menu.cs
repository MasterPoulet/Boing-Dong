using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject jouer;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject quitter;
    private bool jouerOn = false;
    private bool creditOn = false;
    private bool quitterOn = false;


    private void Start()
    {
        jouer.SetActive(false);
        credits.SetActive(false);
        quitter.SetActive(false);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("LD_House");
    }
    
    public void LoadCredit()
    {
        SceneManager.LoadScene("Credits");
    }

    public void CLoseGame()
    {
        Application.Quit();
    }

    public void AfficherJouer()
    {
        if (!jouerOn)
        {
            jouer.SetActive(true);
            jouerOn = true;
        }
        else
        {
            jouer.SetActive(false);
            jouerOn = false;
        }
    }

    public void AfficherCredits()
    {
        if (!creditOn)
        {
            credits.SetActive(true);
            creditOn = true;
        }
        else
        {
            credits.SetActive(false);
            creditOn = false;
        }
    }

    public void AfficherQuitter()
    {
        if (!quitterOn)
        {
            quitter.SetActive(true);
            quitterOn = true;
        }
        else
        {
            quitter.SetActive(false);
            quitterOn = false;
        }
    }
}
