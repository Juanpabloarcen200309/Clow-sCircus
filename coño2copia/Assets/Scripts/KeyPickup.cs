using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public Image displayImage;  // UI Image en el Canvas
    public Sprite[] notes;      // Array de imágenes de las notas
    public GameObject objetoAparecer;  // Objeto que aparecerá (puerta, llave, etc.)
    public GameObject player; // Referencia al jugador para desactivar su movimiento

    private int index = 0;      // Índice de la imagen actual
    private bool mostrandoNota = false; // Controla si una nota está en pantalla

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player") && !mostrandoNota)
    {
        MostrarPrimeraNota();
        
        // Desactiva la colisión temporalmente para que no siga incrementando el contador
        GetComponent<Collider>().enabled = false;
        
        // Opcionalmente, haz invisible el objeto si lo prefieres
        GetComponent<Renderer>().enabled = false;
    }
}



    private void Update()
    {
        print("entra"+ Input.GetKeyDown(KeyCode.E));
        if (mostrandoNota && Input.GetKeyDown(KeyCode.E))
        {
             
            SiguienteNota();  // Cambia a la siguiente imagen al presionar ESPACIO
        }
    }

    void MostrarPrimeraNota()
    {
        if (notes.Length > 0)  // Asegura que hay notas para mostrar
        {
            index = 0;
            displayImage.sprite = notes[index];  // Asigna la primera imagen
            displayImage.gameObject.SetActive(true);  // Muestra la imagen
            mostrandoNota = true;
            BloquearMovimiento(true);  // Bloquea el movimiento del jugador
        }
    }

    void SiguienteNota()
    {
        index++;

        if (index < notes.Length)  // Si hay más notas, cambia la imagen
        {
            displayImage.sprite = notes[index];
        }
        else
        {
            displayImage.gameObject.SetActive(false);  // Oculta la imagen cuando se acaban las notas
            mostrandoNota = false;
            BloquearMovimiento(false);  // Desbloquea el movimiento del jugador

            // Activa el objeto cuando terminan las notas
            if (objetoAparecer != null)
            {
                objetoAparecer.SetActive(true);
                gameObject.SetActive(false);  // Desactiva la llave una vez recogida
            }
        }
    }

    void BloquearMovimiento(bool estado)
    {
       
        if (player != null)
        {
             print("entra2");
            player.GetComponent<CharacterController>().enabled = !estado;
        }
    }
}
