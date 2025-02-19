using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControladorDatosJuego : MonoBehaviour
{
    public GameObject jugador;
    public string archivoDeGuardado;
    public DatosJuego datosJuego = new DatosJuego();

    private void Awake()
    {
        archivoDeGuardado = Application.persistentDataPath + "/datosJuego.json";
        jugador = GameObject.FindGameObjectWithTag("Player");
        CargarDatos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CargarDatos();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardarDatos();
        }
    }

    private void CargarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);

            Debug.Log("Posición del jugador cargada: " + datosJuego.posicion);

            CharacterController cc = jugador.GetComponent<CharacterController>();
            Destroy(cc);
            jugador.transform.position = datosJuego.posicion;
            jugador.AddComponent<CharacterController>();

            Physics.SyncTransforms(); // Para actualizar la física correctamente
        }
        else
        {
            Debug.Log("El archivo no existe, no se pueden cargar datos.");
        }
    }

    private void GuardarDatos()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            posicion = jugador.transform.position
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(archivoDeGuardado, cadenaJSON);
        Debug.Log("Posición del jugador guardada.");
    }
}

