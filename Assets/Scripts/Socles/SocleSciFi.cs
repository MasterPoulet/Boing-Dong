using UnityEngine;

public class SocleSciFi : MonoBehaviour
{
    private int EggCount = 0;   // Nombre total d'oeuf détectés

    private const int maxStepEgg = 5;

    public bool scifiFull = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            EggCount++;
        }

        // Vérifier si on atteint le quota demandé
        if (EggCount == maxStepEgg)
        {
            ScifiFull();
        }
    }

    public void ScifiFull()
    {
        Debug.Log("SciFi est plein");
        scifiFull = true;
    }
}
