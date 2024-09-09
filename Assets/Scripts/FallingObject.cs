using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float fallSpeed = 2f; // Velocidad de caída
    public Sprite[] sprites; // Lista de sprites
    private SpriteRenderer spriteRenderer;

    // Nombre del objeto con el que quieres que se destruya al colisionar
    public string playerName; 
    public string endScreenName; 

    private bool isFalling = false;

    int objectId; //Id del prefab indicando el tipo de pastel
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectId = Random.Range(0, sprites.Length);
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

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == playerName)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.RegisterPrefabElimination(objectId); // Registra la eliminación del prefab
            }
        }

        if (other.gameObject.name == playerName || other.gameObject.name == endScreenName)
        {
            Destroy(gameObject); // Destruir el objeto
        }
    }
}
