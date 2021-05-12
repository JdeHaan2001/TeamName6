using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class BuildingCustomizer : EditorWindow
{
    private List<GameObject> _buildingParents = new List<GameObject>();

    private BuildingScriptableObject _buildingSO = null;

    private Vector2Int _gridSize = new Vector2Int(1, 1);

    private Vector3 _origin = Vector3.zero;

    private float _buildingOffset = 5f;

    private bool _destroyLastOnGenerate = true;

    [MenuItem("Custom Menu/Building Customizer")]
    private static void init()
    {
        BuildingCustomizer window = GetWindow<BuildingCustomizer>("Building Customizer");
        window.minSize = new Vector3(300, 200);
        window.maxSize = new Vector3(600, 400);
        window.Show();

    }

    private void OnGUI()
    {
        GUILayout.Label("Generate Building", EditorStyles.boldLabel);

        _buildingSO = (BuildingScriptableObject)EditorGUILayout.ObjectField("Building List", _buildingSO, typeof(BuildingScriptableObject), true);
        if (_buildingSO == null) EditorGUILayout.HelpBox("Scriptable object needs to have a reference", MessageType.Error);

        if (_buildingSO != null)
        {
            SerializedObject serialObj = new SerializedObject(_buildingSO);
            SerializedProperty serialProp = serialObj.FindProperty("BuildingPrefabs");

            EditorGUILayout.PropertyField(serialProp, true);
            serialObj.ApplyModifiedProperties();

            _buildingSO.SpawnOrigin = _origin = EditorGUILayout.Vector3Field(new GUIContent("Spawn origin", "Position of where the building will generate"), _origin);
            _buildingSO.GridSize = _gridSize = EditorGUILayout.Vector2IntField(new GUIContent("Grid size", "Size of the generated city"), _gridSize);
            _buildingSO.BuildingOffset = _buildingOffset = EditorGUILayout.FloatField(new GUIContent("Building offset", "Distance between the buildings"), Mathf.Max(1f, _buildingOffset));
            _buildingSO.DesetroyLastOnGenerate = _destroyLastOnGenerate = EditorGUILayout.Toggle(new GUIContent("Remove after generate", "If set to TRUE, " +
                                                                                                                "the previously generated buildings will be destroyed " +
                                                                                                                "before new buildings are generated"), _destroyLastOnGenerate);
            EditorGUILayout.Space();
            if (GUILayout.Button("Generate")) generate(_gridSize, _buildingSO.BuildingPrefabs, _origin, _buildingOffset);
            EditorGUILayout.Space();
            if (GUILayout.Button("Delete All Buildings")) deleteBuildings();
        }
    }

    private void generate(Vector2Int pGridSize, List<GameObject> pBuildingPrefabs, Vector3 pOrigin, float pGridOffset)
    {
        if(_destroyLastOnGenerate) deleteBuildings();

        GameObject emptyGameObj = new GameObject($"Generated City {pGridSize.x} X {pGridSize.y}");
        emptyGameObj.transform.position = pOrigin;
        _buildingParents.Add(emptyGameObj);

        for (int x = 0; x < pGridSize.x; x++)
        {
            for (int z = 0; z < pGridSize.y; z++)
            {
                GameObject building = pBuildingPrefabs[Random.Range(0, pBuildingPrefabs.Count)];
                GameObject other = PrefabUtility.InstantiatePrefab(building, emptyGameObj.transform) as GameObject;
                other.transform.position = emptyGameObj.transform.position + new Vector3(pGridOffset * x, 0f, pGridOffset * z);
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void deleteBuildings()
    {
        if (_buildingParents.Count > 0)
        {
            foreach (GameObject other in _buildingParents)
                DestroyImmediate(other);

            _buildingParents.Clear();

            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
}
