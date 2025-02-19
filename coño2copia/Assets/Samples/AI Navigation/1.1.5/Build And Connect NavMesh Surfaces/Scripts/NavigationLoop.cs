using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavigationLoop : MonoBehaviour
    {
        NavMeshAgent m_Agent;
        public Transform[] goals = new Transform[3];
        private int m_NextGoal = 1;
        private Transform player; // Referencia al jugador
        public float chaseRange = 5f; // Rango en el que Clowy persigue a Timmy
        private bool isChasing = false; // Para saber si está persiguiendo o patrullando

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                Debug.LogError("No se encontró al jugador con el tag 'Player'");
            }
        }

        void Update()
        {
            if (player == null) return;

            float distanceToPlayer = Vector3.Distance(m_Agent.transform.position, player.position);

            // Si el jugador está en rango, Clowy empieza a perseguirlo
            if (distanceToPlayer <= chaseRange)
            {
                isChasing = true;
            }

            if (isChasing)
            {
                m_Agent.destination = player.position; // Perseguir al jugador
            }
            else
            {
                // Patrulla normal
                float distance = Vector3.Distance(m_Agent.transform.position, goals[m_NextGoal].position);
                if (distance < 0.5f)
                {
                    m_NextGoal = m_NextGoal != 2 ? m_NextGoal + 1 : 0;
                }
                m_Agent.destination = goals[m_NextGoal].position;
            }
        }
    }
}
