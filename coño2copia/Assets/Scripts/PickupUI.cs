using UnityEngine;
using UnityEngine.UI;

public class PickupUI : MonoBehaviour
{
    public GameObject pickupMessage; // UI del mensaje "E RECOGER"
    private bool canPickup = false; // Indica si el jugador está dentro del trigger
    private bool hasPickedUp = false; // Verifica si ya se recogió el objeto
    private GameObject currentObject; // Guarda el objeto que puede recoger

    void Start()
    {
        if (pickupMessage != null)
            pickupMessage.SetActive(false); // Asegurar que el mensaje esté oculto al inicio
    }

    void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E))
        {
            pickupMessage.SetActive(false); // Ocultar mensaje
            hasPickedUp = true; // Marcar que ya se recogió
            Debug.Log("Objeto recogido: " + currentObject.name);

            // Aquí puedes agregar la lógica específica para cada objeto
            if (currentObject.CompareTag("Linterna"))
            {
                // Activar la funcionalidad de la linterna (según tu otro código)
            }
            else if (currentObject.CompareTag("Nota"))
            {
                // Hacer que aparezca la imagen de la nota en pantalla
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Linterna") || other.CompareTag("Nota")) && !hasPickedUp)
        {
            pickupMessage.SetActive(true);
            canPickup = true;
            currentObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Linterna") || other.CompareTag("Nota"))
        {
            pickupMessage.SetActive(false);
            canPickup = false;
        }
    }
}
