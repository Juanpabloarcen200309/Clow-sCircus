using UnityEngine;

public class PlayDoorSound : MonoBehaviour
{
    private AudioSource doorSound;

    private void Awake()
    {
        doorSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        doorSound.Play(); // Prueba si el sonido se reproduce al iniciar la escena
    }

    public void PlaySound()
    {
        if (doorSound != null)
        {
            doorSound.Play();
        }
    }
}
