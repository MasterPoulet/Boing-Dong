using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject mapRDC;
    [SerializeField] private GameObject mapEtage;
    [SerializeField] private GameObject mapSS;

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
    }

    public void FermetureMap()
    {
        mapEtage.SetActive(false);
        mapRDC.SetActive(false);
        mapSS.SetActive(false);
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
