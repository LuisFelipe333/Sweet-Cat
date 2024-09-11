using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoves : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento hacia la izquierda
    private bool isMovingRight = true; // Indica si el objeto sigue moviéndose
    private bool isMovingLeft = false;
    public string tableName;// Nombre del objeto con el que quieres que se detenga al colisionar
    private Animator animator;
    public string NAWalkingRight;
    public string NAWalkingLeft;
    public string endScreenName;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        animator.SetBool(NAWalkingRight, true); // Activar animación
    }

    // Update is called once per frame
    void Update()
    {
        // Mover el objeto hacia la izquierda si está en movimiento
        if (isMovingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (isMovingLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log(other.gameObject.name);
        if (other.gameObject.name == tableName)
        {
            // Detener el movimiento cuando colisiona con otro objeto
            isMovingRight = false;
            animator.SetBool(NAWalkingRight, false);
            TurnBack();
        }

        if (other.gameObject.name == endScreenName)
        {
            Destroy(gameObject); // Destruir el objeto
        }
        
    }

    void TurnBack()
    {
        animator.SetBool(NAWalkingLeft, true);
        isMovingLeft = true;
    }

}
