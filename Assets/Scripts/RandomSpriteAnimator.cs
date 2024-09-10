using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomSpriteAnimator : MonoBehaviour
{

    public Sprite[] allFrames; // Arreglo de todos los fotogramas
    public int numberOfSprites; // Número total de sprites (debe ser igual al número de conjuntos de 3 fotogramas)
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Asegúrate de que hay suficientes fotogramas en el arreglo
        if (allFrames.Length < 3 * numberOfSprites)
        {
            Debug.LogError("No hay suficientes fotogramas en el arreglo.");
            return;
        }

        // Seleccionar un sprite al azar
        int randomSpriteIndex = Random.Range(0, numberOfSprites);

        // Obtener los 3 fotogramas de la fila seleccionada
        Sprite[] selectedFrames = new Sprite[3];
        for (int i = 0; i < 3; i++)
        {
            selectedFrames[i] = allFrames[randomSpriteIndex * 3 + i];
        }

        // Crear la animación con los fotogramas seleccionados
        CreateAnimation(selectedFrames);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateAnimation(Sprite[] selectedFrames)
    {
        // Crear una nueva animación usando esos frames
        AnimationClip clip = new AnimationClip();
        clip.frameRate = 10; // Velocidad de la animación (10 fotogramas por segundo)

        ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[3];
        for (int i = 0; i < 3; i++)
        {
            keyFrames[i] = new ObjectReferenceKeyframe();
            keyFrames[i].time = i * 0.1f; // Tiempo entre fotogramas
            keyFrames[i].value = selectedFrames[i]; // Asigna el fotograma correspondiente
        }

        // Crear una curva para el SpriteRenderer que cambie el sprite
        AnimationUtility.SetObjectReferenceCurve(clip, new EditorCurveBinding
        {
            type = typeof(SpriteRenderer),
            path = "",
            propertyName = "m_Sprite" // Esta es la propiedad que anima el sprite mostrado
        }, keyFrames);

        // Configurar la animación para que se reproduzca en bucle
        clip.wrapMode = WrapMode.Loop; // Establece el modo de repetición

         // Guardar y aplicar el AnimationClip
        AssetDatabase.CreateAsset(clip, "Assets/AnimationClip.anim");
        AssetDatabase.SaveAssets();
        

        // Asignar la animación al Animator
        var overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        overrideController["NPCWalking"] = clip; // Sustituye la animación por la nueva
        animator.runtimeAnimatorController = overrideController;
    }
}
