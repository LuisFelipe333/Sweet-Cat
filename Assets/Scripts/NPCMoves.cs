using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoves : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento hacia la izquierda
    private bool isMovingRight = true; // Indica si el objeto sigue moviéndose
    public string tableName;// Nombre del objeto con el que quieres que se detenga al colisionar

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mover el objeto hacia la izquierda si está en movimiento
        if (isMovingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == tableName)
        {
            // Detener el movimiento cuando colisiona con otro objeto
            isMovingRight = false;
        }
        
    }

}
