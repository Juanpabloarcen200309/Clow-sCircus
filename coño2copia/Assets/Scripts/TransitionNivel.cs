using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionNivel : MonoBehaviour
{
  // Nombre de la escena a la que se quiere ir
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el trigger tiene el tag "Player" (u otro tag especificado)
        if (other.CompareTag("Player"))
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(sceneName);
        }
    }
} 