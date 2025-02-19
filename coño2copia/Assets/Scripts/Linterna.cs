using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Linterna : MonoBehaviour
{
    public Light linterna;
    public bool tieneLinterna = false;
    public bool estaEncendida = false;
    public float energia = 60f;
    public Image barraEnergiaImagen;
    public GameObject linternaObjeto;
    public Transform jugadorCamara;  // Cámara del jugador (FPS)
    public Transform manoLinterna;   // Objeto vacío donde se coloca la linterna
    public float distanciaParaRecoger = 3f;

    void Start()
    {
        linterna.enabled = false;

        if (barraEnergiaImagen != null)
        {
            ActualizarBarraEnergia();
        }
    }

    void Update()
    {
        if (!tieneLinterna && Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, jugadorCamara.position) <= distanciaParaRecoger)
        {
            RecogerLinterna();
        }

        if (tieneLinterna && Input.GetKeyDown(KeyCode.C))
        {
            if (!estaEncendida)
            {
                EncenderLinterna();
            }
            else
            {
                ApagarLinterna();
            }
        }
    }

    void RecogerLinterna()
    {
        tieneLinterna = true;

        // 📌 Hacemos que la linterna sea hija de "ManoLinterna"
        linternaObjeto.transform.SetParent(manoLinterna);

        // 📌 Reseteamos la posición y rotación para que quede bien en la mano
        linternaObjeto.transform.localPosition = Vector3.zero;
        linternaObjeto.transform.localRotation = Quaternion.identity;

        Debug.Log("Linterna recogida y posicionada correctamente.");
    }

    void EncenderLinterna()
    {
        if (energia > 0)
        {
            estaEncendida = true;
            linterna.enabled = true;
            Debug.Log("Linterna encendida.");
            StartCoroutine(ReducirEnergia());
        }
        else
        {
            Debug.Log("No hay suficiente energía para encender la linterna.");
        }
    }

    void ApagarLinterna()
    {
        estaEncendida = false;
        linterna.enabled = false;
        Debug.Log("Linterna apagada.");
        StopCoroutine(ReducirEnergia());
    }

    IEnumerator ReducirEnergia()
    {
        while (estaEncendida && energia > 0)
        {
            yield return new WaitForSeconds(15f);
            energia -= 5f;
            if (energia < 0) energia = 0;

            ActualizarBarraEnergia();
            Debug.Log("Energía de la linterna: " + energia + "%");

            if (energia <= 0)
            {
                ApagarLinterna();
                Debug.Log("La linterna se apagó por falta de energía.");
                break;
            }
        }
    }

    void ActualizarBarraEnergia()
    {
        if (barraEnergiaImagen != null)
        {
            barraEnergiaImagen.fillAmount = energia / 100f;
        }
    }
}
