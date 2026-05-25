using UnityEngine;

public class SocleNature : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés

    private const int maxStepEgg = 5;

    public bool natureFull = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            EggCount++;
        }

        // Vérifier si on atteint le quota demandé
        if (EggCount == maxStepEgg)
        {
            NatureFull();
        }
    }

    public void NatureFull()
    {
        Debug.Log("Nature est plein");
        natureFull = true;
    }
}
