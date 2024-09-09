using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     public float moveSpeed = 5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        // Captura el movimiento horizontal (flechas izquierda y derecha) y vertical (flechas arriba y abajo)
        movement.x = Input.GetAxisRaw("Horizontal"); // -1 para izquierda, 1 para derecha
        movement.y = Input.GetAxisRaw("Vertical"); // -1 para abajo, 1 para arriba

        // Activar o desactivar la animación Walking
        if (movement != Vector2.zero)
        {
            animator.SetBool("Walking", true); // Activar animación
        }
        else
        {
            animator.SetBool("Walking", false); // Desactivar animación
        }

        // Mover el objeto en un entorno 2D
        transform.position += new Vector3(movement.x, movement.y, 0) * moveSpeed * Time.deltaTime;

        // Usar flipX para girar el sprite cuando se mueva hacia la izquierda o derecha
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Girar el sprite hacia la izquierda
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Mantener el sprite hacia la derecha
        }
    }


}
