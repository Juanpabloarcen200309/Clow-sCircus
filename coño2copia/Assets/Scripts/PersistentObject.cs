using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    private static PersistentObject instance;

    // Lista de escenas donde el objeto debe destruirse
    public string[] prohibitedScenes = { "2cinematica", "ajustes", "resolucion", "audio", "Cinematica", "pantalla inicial" }; // Agrega las escenas necesarias

    void Awake()
    {
        if (IsProhibitedScene(SceneManager.GetActiveScene().name))
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
        if (IsProhibitedScene(scene.name))
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

    // Método para verificar si la escena está en la lista prohibida
    private bool IsProhibitedScene(string sceneName)
    {
        foreach (string prohibitedScene in prohibitedScenes)
        {
            if (sceneName == prohibitedScene)
            {
                return true;
            }
        }
        return false;
    }

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
