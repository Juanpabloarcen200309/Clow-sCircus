using UnityEngine;
using UnityEngine.UI;

public class NotasMati : MonoBehaviour
{
    public Image displayImage; // UI Image en el Canvas
    public Sprite[] images; // Array de imágenes
    private int index = -1; // Índice de la imagen actual
    private bool isActive = false; // Estado de la secuencia
    private bool isPlayerNearby = false; // Para saber si el jugador está cerca

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNearby && !isActive)
        {
            ShowFirstImage();
        }

        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            NextImage();
        }
    }

    void ShowFirstImage()
    {
        isActive = true;
        index = 0;
        displayImage.gameObject.SetActive(true);
        displayImage.sprite = images[index];
    }

    void NextImage()
    {
        index++;
        if (index < images.Length)
        {
            displayImage.sprite = images[index];
        }
        else
        {
            displayImage.gameObject.SetActive(false);
            isActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    } 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
