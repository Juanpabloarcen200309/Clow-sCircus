using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referencia al Video Player

    void Start()
    {
        // Detecta cuándo el video termina automáticamente
        videoPlayer.loopPointReached += EndVideo;
    }

    void Update()
    {
        // Detecta si el jugador presiona la tecla Space para omitir la cinemática
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene("cuarto s"); // Cambia a la escena del juego
        }
    }

    void EndVideo(VideoPlayer vp)
    {
        // Cuando el video termina, cambia automáticamente de escena
        SceneManager.LoadScene("cuarto s");
    }
}
