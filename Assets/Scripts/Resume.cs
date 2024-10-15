using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public GameObject activatePanel;  // El panel que quieres activar
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnResume()
    {
        activatePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
