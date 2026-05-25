using UnityEngine;

public class MusicBell : MonoBehaviour
{
    [SerializeField] private AudioSource musicBellRoom;
    [SerializeField] private AudioSource thunder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicBellRoom.Play();
            thunder.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicBellRoom.Stop();
            thunder.Play();
        }
    }
}
