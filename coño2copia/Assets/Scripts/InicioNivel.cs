using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioNivel : MonoBehaviour{

    public GameObject posIni;
    private GameObject jugador;

private void Awake(){
        jugador = GameObject.FindGameObjectWithTag("Player");
        CargarPos();
    }
 
private void CargarPos(){
        CharacterController cc = jugador.GetComponent<CharacterController>();
        Destroy(cc);
        jugador.transform.position = posIni.transform.position;
        jugador.AddComponent<CharacterController>();
        Physics.SyncTransforms();
    }
}