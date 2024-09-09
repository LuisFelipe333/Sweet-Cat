using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab genérico con la lista de sprites
    public float minSpawnTime = 1f; // Tiempo mínimo entre spawns
    public float maxSpawnTime = 5f; // Tiempo máximo entre spawns

    private Vector2 spawnAreaMin; // Esquina inferior izquierda del área de generación
    private Vector2 spawnAreaMax; // Esquina superior derecha del área de generación
    // Start is called before the first frame update
    void Start()
    {
         // Calcular los límites del área de generación basados en el objeto que contiene este script
        CalculateSpawnAreaBounds();

        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Función para calcular las posiciones mínimas y máximas basadas en los límites del objeto actual
    void CalculateSpawnAreaBounds()
    {
        // Usamos el SpriteRenderer o el BoxCollider2D del propio objeto que contiene este script
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (spriteRenderer != null)
        {
            // Obtener los límites (Bounds) del SpriteRenderer
            Bounds bounds = spriteRenderer.bounds;
            spawnAreaMin = bounds.min; // Esquina inferior izquierda
            spawnAreaMax = bounds.max; // Esquina superior derecha
        }
        else
        {
            Debug.LogError("El objeto no tiene un SpriteRenderer. Agrega uno o usa un BoxCollider2D.");
        }
    }


    IEnumerator SpawnObjects()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime); // Tiempo aleatorio entre spawns
            yield return new WaitForSeconds(waitTime); // Esperar antes de generar otro objeto

            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x), 
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            ); // Posición aleatoria dentro del área definida

            // Generar el objeto usando el prefab genérico
            GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        }
    }
}
