using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Configuracion : MonoBehaviour
{
    // Slider de volumen
    public Slider sliderVolumen;
    public TextMeshProUGUI textoVolumen;

    // Slider de sensibilidad
    public Slider sliderSensibilidad;
    public TextMeshProUGUI textoSensibilidad;

    // Slider de brillo
    public Slider sliderBrillo;
    public TextMeshProUGUI textoBrillo;

    void Start()
    {
        // Asignar los eventos OnValueChanged a los métodos correspondientes
        if (sliderVolumen != null)
            sliderVolumen.onValueChanged.AddListener(delegate { ActualizarVolumen(); });
        if (sliderSensibilidad != null)
            sliderSensibilidad.onValueChanged.AddListener(delegate { ActualizarSensibilidad(); });
        if (sliderBrillo != null)
            sliderBrillo.onValueChanged.AddListener(delegate { ActualizarBrillo(); });
    }

    public void ActualizarVolumen()
    {
        int valorVolumen = Mathf.RoundToInt(sliderVolumen.value); // Convertir a entero
        textoVolumen.text = " " + valorVolumen; // Mostrar el valor como entero
    }

    public void ActualizarSensibilidad()
    {
        int valorSensibilidad = Mathf.RoundToInt(sliderSensibilidad.value); // Convertir a entero
        textoSensibilidad.text = " " + valorSensibilidad; // Mostrar el valor como entero
    }

    public void ActualizarBrillo()
    {
        int valorBrillo = Mathf.RoundToInt(sliderBrillo.value); // Convertir a entero
        textoBrillo.text = " " + valorBrillo; // Mostrar el valor como entero
    }


 // se pone aqui mismo lo del dropdown porque esta en el menu de configuracion
   //pa que se cambie el textito del dropdown
    public TMP_Dropdown miDropDown;
    public TextMeshProUGUI textDropDown;

    public void DropdownUpdate(){
        int indice = miDropDown.value;
        textDropDown.text=miDropDown.options[indice].text + ""; //es como una lista se obtiene el valor que se seleccione de la lista
        }

}
