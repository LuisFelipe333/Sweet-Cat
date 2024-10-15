using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanelKey : MonoBehaviour
{

    public GameObject activatePanel;  // El panel que quieres activar
    public KeyCode toggleKey = KeyCode.Escape; // Tecla para mostrar/ocultar el panel
    public bool pauseTime; // True if you want to stop time

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si se presiona la tecla configurada
        if (Input.GetKeyDown(toggleKey))
        {
            activatePanel.SetActive(true);

            if (pauseTime)
            {
                Time.timeScale = 0;
            }

        }
    }
}
