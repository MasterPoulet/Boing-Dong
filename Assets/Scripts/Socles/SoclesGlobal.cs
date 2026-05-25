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

    public void Update()
    {
        if (easter.easterFull && flower.flowerFull && nature.natureFull && sciFi.scifiFull && metal.metalFull && galaxy.galaxyFull)
        {
            globalfull = true;
        }
    }
}
