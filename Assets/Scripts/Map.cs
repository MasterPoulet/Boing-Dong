using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject mapRDC;
    [SerializeField] private GameObject mapEtage;
    [SerializeField] private GameObject mapSS;

    [SerializeField] private AudioSource mapOpen;
    [SerializeField] private AudioSource mapClose;

    private bool mapActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapRDC.SetActive(false);
        mapEtage.SetActive(false);
        mapSS.SetActive(false);
    }
        
    public void OuvertureMap()
    {
        mapRDC.SetActive(true);
        mapOpen.Play();
        mapActive = true;
    }

    public void FermetureMap()
    {
        if (mapActive)
        {
            mapEtage.SetActive(false);
            mapRDC.SetActive(false);
            mapSS.SetActive(false);
            mapClose.Play();
            mapActive = false;
        }
    }

    public void GoToEtage()
    {
        mapRDC.SetActive(false);
        mapEtage.SetActive(true);
    }

    public void GoToRDC()
    {
        mapEtage.SetActive(false);
        mapRDC.SetActive(true);
        mapSS.SetActive(false);
    }

    public void GoToSS()
    {
        mapRDC.SetActive(false);
        mapSS.SetActive(true);
    }

}
