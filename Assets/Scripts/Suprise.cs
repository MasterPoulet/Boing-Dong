using UnityEngine;

public class Surprise : MonoBehaviour
{
    [SerializeField] AudioSource Fall;

    private bool fait = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !fait)
        {
            Fall.Play();
            fait = true;
        }
    }
}
