using UnityEngine;

public class MusicBell : MonoBehaviour
{
    [SerializeField] private AudioSource musicBellRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicBellRoom.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicBellRoom.Stop();
        }
    }
}
