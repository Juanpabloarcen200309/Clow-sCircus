using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;
    public string lastSceneName = "2cinematica"; // Cambia esto por el nombre real

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == lastSceneName)
        {
            Destroy(gameObject);
            return;
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == lastSceneName)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 📌 Nuevo método para resetear posición del jugador y cámara
    public void ResetPosition(Vector3 nuevaPosicion, Quaternion nuevaRotacion)
    {
        Transform jugador = transform.Find("Capsule"); // Ajusta si tu jugador tiene otro nombre
        Transform camara = transform.Find("Main Camera");

        if (jugador != null)
        {
            jugador.position = nuevaPosicion;
            jugador.rotation = nuevaRotacion;
        }

        if (camara != null)
        {
            camara.position = nuevaPosicion + new Vector3(0, 1.5f, 0); // Ajusta según tu juego
            camara.rotation = nuevaRotacion;
        }
    }
}
