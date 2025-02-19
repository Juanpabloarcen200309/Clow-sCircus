using UnityEngine;

public class ControlPaneles : MonoBehaviour
{
    public GameObject mPrincipal; // Pantalla de inicio
    public GameObject mSalir2;    // Panel que aparece con la tecla ESC

    private bool panelSalirActivo = false; // Controla si el panel de salida está activo

    void Start()
    {
        // Inicializamos los paneles
        mPrincipal.SetActive(true); // Pantalla principal activa al inicio
        mSalir2.SetActive(false);   // Panel de salida oculto al inicio
    }

    void Update()
    {
        // Detecta si la tecla ESC se presiona
        if (Input.GetKeyDown(KeyCode.Escape) && mPrincipal.activeSelf)
        {
            // Alterna entre mostrar y ocultar el panel
            panelSalirActivo = !panelSalirActivo;
            mSalir2.SetActive(panelSalirActivo);
        }
    }

    // Método para regresar al panel principal
    public void VolverAlMenuPrincipal()
    {
        mSalir2.SetActive(false);  // Oculta el panel de salida
        mPrincipal.SetActive(true); // Muestra el panel principal
    }
}

