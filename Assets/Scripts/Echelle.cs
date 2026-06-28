using UnityEngine;

public class Echelle : MonoBehaviour

{
    private bool inEchelle = false;
    [SerializeField] private GameObject echelleOuverte;
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        echelleOuverte.SetActive(false);
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inEchelle = true;
            inventory.echelle = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inEchelle = false;
            inventory.echelle = null;
        }
    }

    public void ActiveEchelle()
    {
        if (inEchelle)
        {
            echelleOuverte.SetActive(true);
        }
    }

}
