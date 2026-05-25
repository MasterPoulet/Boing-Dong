using UnityEngine;

public class SocleGalaxy : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés

    private const int maxStepEgg = 5;

    public bool galaxyFull = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            EggCount++;
        }

        // Vérifier si on atteint le quota demandé
        if (EggCount == maxStepEgg)
        {
            GalaxyFull();
        }
    }

    public void GalaxyFull()
    {
        Debug.Log("Galaxy est plein");
        galaxyFull = true;
    }
}
