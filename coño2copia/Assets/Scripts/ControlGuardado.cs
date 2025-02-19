using UnityEngine;

public class ControlGuardado : MonoBehaviour
{
    public GameObject mGuardar;   // Panel para guardar
    public GameObject mGuardado; // Panel que aparece después de guardar

    void Start()
    {
        // Inicializamos los paneles
        mGuardar.SetActive(true);  // El panel de guardar está activo al inicio
        mGuardado.SetActive(false); // El panel de confirmación está oculto al inicio
    }

    // Método para mostrar el panel de "guardado"
    public void MostrarGuardado()
    {
        mGuardar.SetActive(false);  // Oculta el panel de guardar
        mGuardado.SetActive(true);  // Muestra el panel de guardado exitoso
    }
}
