using UnityEngine;

public class SocleMetal : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés

    private const int maxStepEgg = 5;

    public bool metalFull = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            EggCount++;
        }

        // Vérifier si on atteint le quota demandé
        if (EggCount == maxStepEgg)
        {
            MetalFull();
        }
    }

    public void MetalFull()
    {
        Debug.Log("Metal est plein");
        metalFull = true;
    }
}
