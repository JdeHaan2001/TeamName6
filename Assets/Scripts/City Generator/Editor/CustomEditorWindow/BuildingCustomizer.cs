using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class BuildingCustomizer : EditorWindow
{
    private List<GameObject> prefabList = new List<GameObject>();
    private List<GameObject> buildingList = new List<GameObject>();

    private BuildingScriptableObject buildingSO = null;
    private GridGenerator _generationScript = null;

    private Vector2Int _gridSize = new Vector2Int(1, 1);

    private Vector3 _origin = Vector3.zero;

    private float _buildingOffset = 5f;

    [MenuItem("Custom Menu/Building Customizer")]
    private static void init()
    {
        BuildingCustomizer window = GetWindow<BuildingCustomizer>("Building Customizer");
        window.minSize = new Vector3(300, 200);
        window.maxSize = new Vector3(600, 400);
        window.Show();

    }
    private void Awake() => _generationScript = new GridGenerator();

    private void OnGUI()
    {
        GUILayout.Label("Generate Building", EditorStyles.boldLabel);

        buildingSO = (BuildingScriptableObject)EditorGUILayout.ObjectField("Building List", buildingSO, typeof(BuildingScriptableObject), true);
        if (buildingSO == null) EditorGUILayout.HelpBox("Scriptable object needs to have a reference", MessageType.Error);

        if (buildingSO != null)
        {
            SerializedObject serialObj = new SerializedObject(buildingSO);
            SerializedProperty serialProp = serialObj.FindProperty("BuildingPrefabs");
            

            EditorGUILayout.PropertyField(serialProp, true);
            serialObj.ApplyModifiedProperties();
        }

        _origin = EditorGUILayout.Vector3Field("Spawn origin", _origin);
        _gridSize = EditorGUILayout.Vector2IntField("Grid size", _gridSize);
        _buildingOffset = EditorGUILayout.FloatField("Building offset", Mathf.Max(1f, _buildingOffset));

        if (GUILayout.Button("Generate")) Generate(_gridSize, buildingSO.BuildingPrefabs, _origin, _buildingOffset);
    }

    public void Generate(Vector2Int pGridSize, List<GameObject> pBuildingPrefabs, Vector3 pOrigin, float pGridOffset)
    {
        if (buildingList.Count > 0)
        {
            foreach (GameObject other in buildingList)
            {
                DestroyImmediate(other);
            }
            buildingList.Clear();
        }
        for (int x = 0; x < pGridSize.x; x++)
        {
            for (int z = 0; z < pGridSize.y; z++)
            {
                GameObject building = pBuildingPrefabs[Random.Range(0, pBuildingPrefabs.Count)];
                GameObject other = PrefabUtility.InstantiatePrefab(building) as GameObject;
                other.transform.position = pOrigin + new Vector3(pGridOffset * x, 0f, pGridOffset * z);

                buildingList.Add(other);
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}
