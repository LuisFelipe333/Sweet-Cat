using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Define un array 2D para almacenar el ID del prefab y el conteo de eliminaciones
    public int[,] prefabEliminationCounts;

    public int numberOfPrefabTypes; // Número de variaciones de prefab

    public bool printCounts; //Print counts for debug
    public int dessertsObtained;
    public int dessertSold;
    public GameObject obtainedText;
    public GameObject soldText;
    public GameObject timerText;
    public float timeRemaining;
    public GameObject finalPanel;  // El panel que quieres activar
    public GameObject SalesText;
    public GameObject ExpensesText;
    public GameObject ProfitText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        dessertsObtained = 0;
        dessertSold = 0;
        printCounts = false;
        // Inicializa el array 2D con tamaño (n, 2)
        prefabEliminationCounts = new int[numberOfPrefabTypes, 2];

        // Inicializa los IDs en la primera columna y los conteos en la segunda columna
        for (int i = 0; i < numberOfPrefabTypes; i++)
        {
            prefabEliminationCounts[i, 0] = i; // Asigna el ID
            prefabEliminationCounts[i, 1] = 0; // Inicializa el conteo a 0
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining = timeRemaining - Time.deltaTime;
            if (timeRemaining > 0)
            {
                timerText.GetComponentInChildren<TextMeshProUGUI>().text = "Time:   " + Mathf.FloorToInt(timeRemaining).ToString();   
            }
        }
        else
        {
            timerText.GetComponentInChildren<TextMeshProUGUI>().text = "Time:   0";
            SalesText.GetComponentInChildren<TextMeshProUGUI>().text = "Sales:       $" + (dessertSold * 5).ToString();
            ExpensesText.GetComponentInChildren<TextMeshProUGUI>().text = "Expenses: $" + (dessertsObtained * 2).ToString();
            ProfitText.GetComponentInChildren<TextMeshProUGUI>().text = "Profit:    $" + ((dessertSold * 5)- (dessertsObtained * 2)).ToString();

            finalPanel.SetActive(true);
            Time.timeScale = 0;
                
        }
        

    }

    public void RegisterPrefabElimination(int prefabID)
    {
        if (prefabID >= 0 && prefabID < numberOfPrefabTypes)
        {
            // Incrementa el conteo para el prefab con el ID especificado
            prefabEliminationCounts[prefabID, 1]++;
            FindObjectOfType<DessertUIPoints>().UpdatePrefabText(prefabID, prefabEliminationCounts[prefabID, 1]);
        }
        else
        {
            Debug.LogWarning("Prefab ID out of range: " + prefabID);
        }

        dessertsObtained++;
        UpdateInGameData();

        // Debug.Log(dessertsObtained);

        if(printCounts)
        {
            PrintEliminationCounts();
        }
    }


    public void PrintEliminationCounts()
    {
        Debug.Log("---------------------------------");
        for (int i = 0; i < numberOfPrefabTypes; i++)
        {
            Debug.Log($"Prefab ID: {prefabEliminationCounts[i, 0]}, Count: {prefabEliminationCounts[i, 1]}");
        }
    }

    public void UpdateInGameData()
    {
        obtainedText.GetComponentInChildren<TextMeshProUGUI>().text = "Obtained:  " + dessertsObtained;
        soldText.GetComponentInChildren<TextMeshProUGUI>().text = "Sold        :  " + dessertSold;
    }


}
