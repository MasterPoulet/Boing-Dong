using UnityEngine;

public class MusicIIntro : MonoBehaviour
{
    [SerializeField] AudioSource Ambiant;
    [SerializeField] AudioSource Wood;

    private bool fait = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !fait)
        {
            Ambiant.Play();
            Wood.Play();
            fait = true;
        }
    }
}
