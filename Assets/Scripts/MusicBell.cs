using UnityEngine;

public class MusicBell : MonoBehaviour
{
    [SerializeField] private AudioSource musicBellRoom;
    [SerializeField] private AudioSource thunder;
    [SerializeField] private AudioSource ambiant;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicBellRoom.Play();
            thunder.Stop();
            ambiant.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicBellRoom.Stop();
            thunder.Play();
            ambiant.Play();
        }
    }
}
