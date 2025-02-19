using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform player; // El jugador al que el enemigo perseguirá
    private NavMeshAgent agent; // Para mover al enemigo
    private Animator animator; // Para animaciones
    private bool isChasing = false; // Estado de persecución
    private AudioSource audioSource; // Para reproducir sonido
    public AudioClip chaseSound; // Sonido cuando empieza la persecución

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Obtiene el AudioSource

        // Desactivar la persecución al inicio
        isChasing = false;
    }

    void Update()
    {
        // Si el enemigo está persiguiendo
        if (isChasing && player != null)
        {
            agent.SetDestination(player.position);
            animator.SetBool("isChasing", true); // Cambia la animación a perseguidor
        }
    }

    // Método que se llama cuando el ruido alcanza el máximo
    public void StartChasing()
    {
        if (!isChasing) // Solo ejecuta si aún no estaba persiguiendo
        {
            isChasing = true;
            Debug.Log("¡El enemigo te está persiguiendo!");

            // Reproducir sonido si hay un clip asignado
            if (audioSource != null && chaseSound != null)
            {
                audioSource.PlayOneShot(chaseSound);
            }
        }
    }

    // Método para asignar el jugador si no está asignado
    public void SetPlayer(Transform newPlayer)
    {
        player = newPlayer;
    }
}
