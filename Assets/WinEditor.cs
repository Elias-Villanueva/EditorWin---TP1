using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WinEditor : EditorWindow {

    float objectScale;

    Color color;

    [MenuItem("Window/Editor")]
    public static void ShowWindow() 
    {
        var window = GetWindow<WinEditor>("Editor");
    }

    void OnGUI() 
    {
        GUILayout.Label("Edita el objeto seleccionado", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("Colorear"))
        {
            Colorize();
        }

        objectScale = EditorGUILayout.Slider("Escalar deseada", objectScale, 1f, 50f);

        if (GUILayout.Button("Escalar"))
        {
            Agrandar();
        }

    }

    // Start is called before the first frame update
    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = color;
            }
        }
    }

    // Update is called once per frame
    void Agrandar()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {

           obj.transform.localScale = Vector3.one * objectScale;
        }
    }
    
}
