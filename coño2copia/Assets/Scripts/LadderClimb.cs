using UnityEngine;
using UnityEngine.SceneManagement; // Importar el sistema de manejo de escenas
using StarterAssets;

public class LadderClimb : MonoBehaviour
{
    public float climbSpeed = 2f;  // Velocidad de escalada
    public string nextSceneName;  // Nombre de la escena a cargar
    private FirstPersonController playerController;  // Referencia al controlador de primera persona
    private CharacterController characterController;  // Referencia al componente CharacterController
    private bool isClimbing = false;  // Bandera para determinar si está escalando
    private float verticalInput;  // Entrada vertical

    private SceneTransition sceneTransition;  // Referencia al script de transición de escena

    private void Start()
    {
        playerController = GetComponent<FirstPersonController>();
        characterController = GetComponent<CharacterController>();

        // Encontrar el script SceneTransition en la escena
        sceneTransition = FindObjectOfType<SceneTransition>();

        if (sceneTransition == null)
        {
            Debug.LogError("No se encontró SceneTransition en la escena. Asegúrate de que haya un objeto con ese script.");
        }
        playerController.enabled=true;
    }

    private void Update()
    {
        if (isClimbing)
        {
            // Obtener entrada vertical
            verticalInput = Input.GetAxis("Vertical");

            // Escalar normalmente
            ClimbLadder();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
            playerController.enabled = false;  // Desactivar control estándar
        }

        // Si el jugador llega al tope de la escalera (trigger en la parte superior)
        if (other.CompareTag("LadderTop"))
        {
            ChangeSceneWithFade();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            ExitLadder();
        }
    }

    private void ClimbLadder()
    {
        Vector3 moveDirection = Vector3.up * verticalInput * climbSpeed * Time.deltaTime;
        characterController.Move(moveDirection);
    }

    private void ExitLadder()
    {
        isClimbing = false;
        playerController.enabled = true;  // Reactivar el control estándar
    }

    private void ChangeSceneWithFade()
    {
        if (sceneTransition != null)
        {
            sceneTransition.ChangeScene(nextSceneName); // Usar SceneTransition para hacer el fade y cambiar la escena
        ExitLadder();  
        }
        else
        {
            Debug.LogError("SceneTransition no está asignado. Asegúrate de que hay un objeto con ese script en la escena.");
        }
    }
}
