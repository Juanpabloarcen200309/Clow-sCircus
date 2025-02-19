using UnityEngine;
using UnityEngine.SceneManagement;

public class RestarGame : MonoBehaviour
{
    public void IrACuartoS()
    {
        // 📌 Si el objeto Persistente existe, elimínalo antes de recargar
        PersistentObject persistente = FindObjectOfType<PersistentObject>();
        if (persistente != null)
        {
            Destroy(persistente.gameObject);
        }

        // 📌 Recarga la escena "cuarto s" como si fuera la primera vez
        SceneManager.LoadScene("cuarto s");
    }
}
