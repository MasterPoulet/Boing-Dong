using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SprintTuto : MonoBehaviour
{

    [SerializeField] private GameObject UiSprintTuto;
    [SerializeField] private GameObject ColliderSprintTuto;
    [SerializeField] private GameObject Ebind;

    private void Start()
    {
        UiSprintTuto.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        UiSprintTuto.SetActive(true);
        Destroy(Ebind);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift) && UiSprintTuto.activeInHierarchy)
        {
            UiSprintTuto.SetActive(false);
            ColliderSprintTuto.SetActive(false);
            Destroy(this);
        }
    }
}
