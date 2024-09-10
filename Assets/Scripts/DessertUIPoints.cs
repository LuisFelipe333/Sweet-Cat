using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DessertUIPoints : MonoBehaviour
{
    public GameObject prefabUIPanel; // Prefab del panel que contiene la Image y Text
    public Transform uiParentPanel; // Panel padre que contendrá los UIPanels
    public Sprite[] prefabSprites; // Array de sprites correspondientes a los prefabs
    public Vector2 startPosition = new Vector2(0, -50); // Posición inicial del primer prefab
    public float verticalSpacing = 50f; // Espaciado entre los prefabs
    private GameObject[] spawnedUIPanels; // Almacena los prefabs generados para actualizarlos luego

    // Start is called before the first frame update
    void Start()
    {
        InitializeUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método que inicializa los prefabs en la UI
    void InitializeUI()
    {
        // Inicializamos el array que contendrá los prefabs generados
        spawnedUIPanels = new GameObject[prefabSprites.Length];

        for (int i = 0; i < prefabSprites.Length; i++)
        {
            // Instancia un panel en el padre con el prefab
            GameObject panel = Instantiate(prefabUIPanel, uiParentPanel);

            // Coloca la posición del panel basándose en la posición inicial y el espaciado
            RectTransform panelRect = panel.GetComponent<RectTransform>();
            panelRect.anchoredPosition = startPosition - new Vector2(0, i * verticalSpacing);

            // Cambia el sprite de la imagen
            Image image = panel.transform.Find("DessertImage").GetComponent<Image>();
            image.sprite = prefabSprites[i];

            // Inicializa el texto en 0
            TextMeshProUGUI textComponent = panel.transform.Find("TextDessertPoints").GetComponent<TextMeshProUGUI>();
            textComponent.text = "x0";

            // Guarda el panel instanciado para futuras actualizaciones
            spawnedUIPanels[i] = panel;
        }
    }

    // Método para actualizar el texto del prefab en una posición específica (usando su ID)
    public void UpdatePrefabText(int id, int newValue)
    {
        if (id >= 0 && id < spawnedUIPanels.Length)
        {
            // Actualiza el texto con el nuevo valor
            TextMeshProUGUI textComponent = spawnedUIPanels[id].transform.Find("TextDessertPoints").GetComponent<TextMeshProUGUI>();
            textComponent.text = "x" + newValue.ToString();
        }
        else
        {
            Debug.LogWarning("ID fuera de rango. No se puede actualizar el texto.");
        }
    }
}
