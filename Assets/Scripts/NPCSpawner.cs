using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab genérico con la lista de sprites
    private GameObject NPC1;
    private GameObject NPC2;

    int NeededDesserts;
    int SpriteDesserts;
    public bool DebugBool = false;
    public string playerName;
    private bool canDeleted = false;

    // Start is called before the first frame update
    void Start()
    {
        CreateNPC();
    }

    // Update is called once per frame
    void Update()
    {
        if(DebugBool)
        {
            DeliverOrder();
        }
    }

    public void CreateNPC()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x-100, transform.position.y);
        NPC1 = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        NeededDesserts = Random.Range(1, 4);
        NPC1.GetComponent<NPCMoves>().UpdateText(NeededDesserts.ToString());
        SpriteDesserts = Random.Range(0, 5);
        NPC1.GetComponent<NPCMoves>().setDessert(SpriteDesserts);
        StartCoroutine(ActivateDeleted());
    }

    public void DeliverOrder()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if(gameManager.prefabEliminationCounts[SpriteDesserts, 1] >= NeededDesserts)
        {
            // Debug.Log("" + gameManager.prefabEliminationCounts[SpriteDesserts, 1]);
            gameManager.prefabEliminationCounts[SpriteDesserts, 1] = gameManager.prefabEliminationCounts[SpriteDesserts, 1] - NeededDesserts;
            NPC1.GetComponent<NPCMoves>().UpdateText("");
            NPC1.GetComponent<NPCMoves>().TurnBack();
            canDeleted = false;
            gameManager.dessertSold = gameManager.dessertSold + NeededDesserts;
            Debug.Log("Vendidos: " +  gameManager.dessertSold);
            Debug.Log("Restantes de " + SpriteDesserts + ": " +  gameManager.prefabEliminationCounts[SpriteDesserts, 1]);
            FindObjectOfType<DessertUIPoints>().UpdatePrefabText(SpriteDesserts, gameManager.prefabEliminationCounts[SpriteDesserts, 1]);
            gameManager.UpdateInGameData();

            StartCoroutine(DelayedCreateNPC());
        }
        else
        {
            if(gameManager.prefabEliminationCounts[SpriteDesserts, 1] > 0)
            {
                int soldIt = gameManager.prefabEliminationCounts[SpriteDesserts, 1];
                NeededDesserts = NeededDesserts - soldIt;
                gameManager.dessertSold = gameManager.dessertSold + soldIt;
                gameManager.prefabEliminationCounts[SpriteDesserts, 1] = 0;
                NPC1.GetComponent<NPCMoves>().UpdateText(NeededDesserts.ToString());
                Debug.Log("Vendidos: " +  gameManager.dessertSold);
                Debug.Log("Restantes de " + SpriteDesserts + ": " +  gameManager.prefabEliminationCounts[SpriteDesserts, 1]);
                FindObjectOfType<DessertUIPoints>().UpdatePrefabText(SpriteDesserts, 0);
                gameManager.UpdateInGameData();

            }
            

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == playerName && canDeleted)
        {
            DeliverOrder();
        }
    }
    
    private IEnumerator DelayedCreateNPC()
    {
        // Espera 0.5 segundos antes de ejecutar CreateNPC
        yield return new WaitForSeconds(0.5f);
        
        // Ejecuta el método CreateNPC
        CreateNPC();
    }

    private IEnumerator ActivateDeleted()
    {
        // Espera 0.5 segundos antes de ejecutar CreateNPC
        yield return new WaitForSeconds(3f);
        
        canDeleted = true;
    }

}
