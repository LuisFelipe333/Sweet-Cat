using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método que se llama cuando se presiona el botón
    public void QuitGame()
    {
        // Sale de la aplicación
        Application.Quit();

        // Este código solo funciona en una compilación, 
        // no en el editor de Unity, así que es útil mostrar un mensaje en el editor
        #if UNITY_EDITOR
        Debug.Log("El juego se ha cerrado (simulado en el editor).");
        #endif
    }
}
