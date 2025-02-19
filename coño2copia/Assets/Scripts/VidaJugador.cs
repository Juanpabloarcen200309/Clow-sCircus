
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Vida máxima del jugador
    [SerializeField] private int currentHealth;
    [SerializeField] private Image healthBar; // Referencia a la barra de vida
    [SerializeField] private float damageInterval = 1f; // Intervalo de tiempo entre cada daño
    private float damageTimer;

    private void Start()
    {
        currentHealth = maxHealth; // Inicializar la vida del jugador
        UpdateHealthBar(); // Actualizar la barra de vida al inicio
    }

    private void Update()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") && damageTimer <= 0)
        {
            TakeDamage(10);
            damageTimer = damageInterval;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    private void Die()
    {
        Debug.Log("Jugador ha muerto");
    }
}