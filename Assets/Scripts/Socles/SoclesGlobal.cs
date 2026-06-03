using UnityEngine;

public class SoclesGlobal : MonoBehaviour
{
    // autres scripts
    [SerializeField] private SocleEaster easter;
    [SerializeField] private SocleFlower flower;
    [SerializeField] private SocleNature nature;
    [SerializeField] private SocleSciFi sciFi;
    [SerializeField] private SocleMetal metal;
    [SerializeField] private SocleGalaxy galaxy;

    public bool globalfull = false;

    [SerializeField] private GameObject vitre;
    [SerializeField] private GameObject RedKeyF;
    [SerializeField] private GameObject RedKeyV;

    [SerializeField] private GameObject EndGame;   
    [SerializeField] private GameObject lapinou;


    private void Start()
    {
        vitre.SetActive(true);
        RedKeyF.SetActive(true);
        RedKeyV.SetActive(false);
        EndGame.SetActive(false);
    }

    public void Update()
    {
        //RedKey
        if (easter.easterFull && flower.flowerFull && nature.natureFull && sciFi.scifiFull && metal.metalFull)
        {
            globalfull = true;
            vitre.SetActive(false);
            RedKeyF.SetActive(false);
            RedKeyV.SetActive(true);
        }

        if (easter.easterFull && flower.flowerFull && nature.natureFull && sciFi.scifiFull && metal.metalFull && galaxy.galaxyFull)
        {
            globalfull = true;
            EndGame.SetActive(true);
            lapinou.SetActive(false);
        }
    }
}
