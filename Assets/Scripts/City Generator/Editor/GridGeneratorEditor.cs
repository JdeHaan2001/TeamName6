//Made by Jeroen de haan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingStacker))]
public class GridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BuildingStacker buildingGenerator = (BuildingStacker)target;
        if (GUILayout.Button("Generate"))
        {
            buildingGenerator.Generate();
        }
    }
}
