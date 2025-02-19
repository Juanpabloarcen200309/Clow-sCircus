using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public string playerTag = "Player"; // Tag del jugador
    public string cameraName = "MainCamera"; // Nombre de la cámara
    public float detectionRange = 5f; // Rango de detección
    public Animator animator; // Referencia al Animator
    private Camera mainCamera; // Referencia a la cámara principal

    void Start()
    {
        // Buscar la cámara por su nombre
        GameObject cameraObject = GameObject.Find(cameraName);
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();
        }
    }

    void Update()
    {
        // Buscar al jugador por su tag
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            // Calcular la distancia entre el enemigo y el jugador
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Si el jugador está dentro del rango de detección, activar la animación
            if (distanceToPlayer <= detectionRange)
            {
                animator.SetTrigger("Scream");
                PointCameraAtClown();
            }
        }
    }

    void PointCameraAtClown()
    {
        // Mover la cámara para que apunte a la cara del payaso
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z - 2f);
            mainCamera.transform.LookAt(transform);
        }
    }
}