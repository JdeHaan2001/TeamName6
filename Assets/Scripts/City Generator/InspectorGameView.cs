//Made by Jeroen de haan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InspectorGameView : MonoBehaviour
{
    private void OnGUI()
    {
        Editor editor = Editor.CreateEditor(gameObject);

        Rect testRect = new Rect();
        testRect.center = Vector2.one * 200;

        GUILayout.BeginArea(testRect);
        editor.DrawDefaultInspector();
        GUILayout.EndArea();
    }
}
