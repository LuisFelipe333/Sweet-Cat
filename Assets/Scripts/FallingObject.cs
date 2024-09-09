using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 2f; // Velocidad de caída
    public Sprite[] sprites; // Lista de sprites
    private SpriteRenderer spriteRenderer;

    private bool isFalling = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int objectId = Random.Range(0, sprites.Length);
        SetSprite(objectId);
        StartFalling();
    }

    public void StartFalling()
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

    public void SetSprite(int id)
    {
        if (id >= 0 && id < sprites.Length)
        {
            spriteRenderer.sprite = sprites[id]; // Asignar el sprite correspondiente
        }
        else
        {
            Debug.LogWarning("ID fuera de rango, no se asignó ningún sprite.");
        }
    }
}
