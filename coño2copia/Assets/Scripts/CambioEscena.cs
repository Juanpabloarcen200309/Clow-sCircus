using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;//importar libreria que permite cambiar las escenas

public class CambioEscena : MonoBehaviour //NO SE NECESITA NI EL UPDATE NI EL START
{
    public void CambiarAEscena(string nombreEscena) { //variable de tipo string recibe un valor. publico para definir en unity que ese es el metodo para cambiar de escena
        SceneManager.LoadScene(nombreEscena); //cambia la escena a ese nombre
    }

    
}
