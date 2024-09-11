using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject objectPrefab; // Prefab genérico con la lista de sprites
    private GameObject NPC1;
    private GameObject NPC2;

    // Start is called before the first frame update
    void Start()
    {
        CreateNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNPC()
    {
        Vector2 spawnPosition = new Vector2(transform.position.x-100, transform.position.y);
        NPC1 = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        int NeededDesserts = Random.Range(1, 4);
        NPC1.GetComponent<NPCMoves>().UpdateText(NeededDesserts);
        int SpriteDesserts = Random.Range(0, 5);
         NPC1.GetComponent<NPCMoves>().setDessert(SpriteDesserts);
    }



}
