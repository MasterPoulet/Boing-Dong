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
        
    public void GestionMap()
    {

    }

}
