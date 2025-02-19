using UnityEngine;

public class DoorTrigger : MonoBehaviour
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
            sceneTransition.ChangeScene("circo"); // Cambia "NombreDeLaEscena"
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
