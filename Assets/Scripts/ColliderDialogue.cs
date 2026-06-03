using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class ColliderDialogue : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bulle"))
        {
            StartCoroutine(Attendre1seconde());
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    IEnumerator Attendre1seconde()
    {
        yield return new WaitForSeconds(1f);

        if (boxCollider != null)
        {
            Destroy(this);
        }
    }
}
