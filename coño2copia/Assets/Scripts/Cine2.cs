using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cine2 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private bool videoStarted = false; // Variable para detectar si el video ya empezó

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += EndVideo;
            videoPlayer.started += OnVideoStarted; // Evento cuando el video comienza
            Debug.Log("Evento loopPointReached asignado correctamente.");
        }
        else
        {
            Debug.LogError("No se encontró el VideoPlayer en este objeto.");
        }
    }

    void Update()
    {
        if (videoStarted && !videoPlayer.isPlaying) // Solo cambia de escena si el video ya empezó y terminó
        {
            Debug.Log("El video terminó (comprobado con isPlaying). Cambiando de escena...");
            SceneManager.LoadScene("pantalla inicial");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Tecla SPACE presionada, cambiando de escena...");
            SceneManager.LoadScene("pantalla inicial");
        }
    }

    void EndVideo(VideoPlayer vp)
    {
        Debug.Log("El video terminó, intentando cambiar de escena...");
        SceneManager.LoadScene("pantalla inicial");
    }

    void OnVideoStarted(VideoPlayer vp)
    {
        videoStarted = true; // Ahora sabemos que el video ha comenzado correctamente
    }
}
