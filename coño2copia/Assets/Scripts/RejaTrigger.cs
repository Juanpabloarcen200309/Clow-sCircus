using UnityEngine;

public class RejaTrigger : MonoBehaviour
{
    private bool playerIsNear = false;
    private SceneTransition sceneTransition;

    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>(); // Busca el script de transición
    }

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            sceneTransition.ChangeScene("cuarto s"); // Cambia "NombreDeLaEscena"
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
        }
    }
}
