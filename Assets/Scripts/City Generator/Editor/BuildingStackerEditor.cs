//Made by Jeroen de haan

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class BuildingStackerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridGenerator gridGenerator = (GridGenerator)target;
        if (GUILayout.Button("Generate"))
        {
            gridGenerator.GenerateGrid();
        }
    }
}
