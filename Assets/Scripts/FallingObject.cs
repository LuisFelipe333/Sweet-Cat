using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 2f; // Velocidad de caída

    private bool isFalling = false;
    // Start is called before the first frame update
    void Start()
    {
        isFalling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime; // Movimiento hacia abajo
        }
    }
}
