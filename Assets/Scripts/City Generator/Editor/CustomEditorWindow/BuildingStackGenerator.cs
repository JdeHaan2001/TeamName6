using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class BuildingStackGenerator : EditorWindow
{
    private List<GameObject> _buildingParents = new List<GameObject>();

    private BuildingScriptableObject _buildingSO = null;

    private Vector2Int _gridSize = new Vector2Int(1, 1);

    private Vector3 _origin = Vector3.zero;

    private float _buildingOffset = 5f;

    private bool _destroyLastOnGenerate = true;
    private bool _useStackedBuildings = false;
    private bool _randomBuildingHeight = false;

    private int _buildingHeight = 1;
    private int _maxBuildingHeight = 3;

    [MenuItem("Custom Menu/City Generator/Stack Buildings")]
    private static void init()
    {
        BuildingStackGenerator window = GetWindow<BuildingStackGenerator>("Stack City Generator");
        window.minSize = new Vector3(300, 200);
        window.maxSize = new Vector3(600, 400);
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Generate Building", EditorStyles.boldLabel);

        _buildingSO = (BuildingScriptableObject)EditorGUILayout.ObjectField("Building List", _buildingSO, typeof(BuildingScriptableObject), true);

        if (_buildingSO == null) EditorGUILayout.HelpBox("Scriptable object needs to have a reference", MessageType.Error);
        else
        {
            SerializedObject serialObj = new SerializedObject(_buildingSO);
            

            _buildingSO.UseStackedBuildings = _useStackedBuildings = EditorGUILayout.Toggle(new GUIContent("Use building stacker", "If set to TRUE, " +
                                                                                                           "multiple lists wil show to add floor prefabs " +
                                                                                                           "for the building stacker"), _useStackedBuildings);
            if (_useStackedBuildings)
            {
                GUILayout.Label("Stacked Building", EditorStyles.boldLabel);
                SerializedProperty serialBaseFloor = serialObj.FindProperty("BaseFloorPrefabs");
                EditorGUILayout.PropertyField(serialBaseFloor, true);
                SerializedProperty serialNormalFloor = serialObj.FindProperty("NormalFloorPrefabs");
                EditorGUILayout.PropertyField(serialNormalFloor, true);
                SerializedProperty serialRoof = serialObj.FindProperty("RoofPrefabs");
                EditorGUILayout.PropertyField(serialRoof, true);
                EditorGUILayout.Space();
                _buildingSO.RandomHeight = _randomBuildingHeight = EditorGUILayout.Toggle(new GUIContent("Random Building Height", "Is set to TRUE" +
                                                                                                         "the stacked building will have " +
                                                                                                         "a random height"), _randomBuildingHeight);
                if (!_randomBuildingHeight)
                    _buildingSO.BuildingStackHeight = _buildingHeight = EditorGUILayout.IntField(new GUIContent("Building Height",
                                                                                                                "Height of the stacked building"), _buildingHeight);
                else
                    _buildingSO.MaxBuildingStackHeight = _maxBuildingHeight = EditorGUILayout.IntField(new GUIContent("Max Building Height",
                                                                                                       "Max height of the building"), _maxBuildingHeight);
                serialObj.ApplyModifiedProperties();
            }
            else
            {
                SerializedProperty serialProp = serialObj.FindProperty("BuildingPrefabs");

                EditorGUILayout.PropertyField(serialProp, true);
                serialObj.ApplyModifiedProperties();
            }

            EditorGUILayout.Space();
            GUILayout.Label("Spawn Settings", EditorStyles.boldLabel);
            _buildingSO.SpawnOrigin = _origin = EditorGUILayout.Vector3Field(new GUIContent("Spawn origin", "Position of where the building will generate"), _origin);
            _buildingSO.GridSize = _gridSize = EditorGUILayout.Vector2IntField(new GUIContent("Grid size", "Size of the generated city"), _gridSize);
            _buildingSO.BuildingOffset = _buildingOffset = EditorGUILayout.FloatField(new GUIContent("Building offset", "Distance between the buildings"), Mathf.Max(1f, _buildingOffset));
            _buildingSO.DesetroyLastOnGenerate = _destroyLastOnGenerate = EditorGUILayout.Toggle(new GUIContent("Remove after generate", "If set to TRUE, " +
                                                                                                                "the previously generated buildings will be destroyed " +
                                                                                                                "before new buildings are generated"), _destroyLastOnGenerate);
            EditorGUILayout.Space();
            if (GUILayout.Button("Generate")) _buildingSO.Generate(_buildingSO.BuildingPrefabs, _buildingParents);
                EditorGUILayout.Space();
            if (GUILayout.Button("Delete All Buildings")) _buildingSO.DeleteBuildings(_buildingParents);
        }
    }

    //private void generate(Vector2Int pGridSize, List<GameObject> pBuildingPrefabs, Vector3 pOrigin, float pGridOffset)
    //{
    //    if(_destroyLastOnGenerate) deleteBuildings();

    //    GameObject emptyGameObj = new GameObject($"Generated City {pGridSize.x} X {pGridSize.y}");
    //    emptyGameObj.transform.position = pOrigin;
    //    _buildingParents.Add(emptyGameObj);

    //    for (int x = 0; x < pGridSize.x; x++)
    //    {
    //        for (int z = 0; z < pGridSize.y; z++)
    //        {
    //            if (_useStackedBuildings)
    //                stackBuilding(emptyGameObj.transform, pOrigin, pGridOffset, x, z);
    //            else
    //                spawnBuildings(emptyGameObj.transform, x, z);
    //        }
    //    }
    //    EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    //}

    //private void spawnBuildings(Transform pParent, int pX, int pZ)
    //{
    //    int randomIndex = Random.Range(0, _buildingSO.BuildingPrefabs.Count);
    //    GameObject building = PrefabUtility.InstantiatePrefab(_buildingSO.BuildingPrefabs[randomIndex]) as GameObject;
    //    building.transform.position = new Vector3(pX * _buildingOffset, _origin.y, pZ * _buildingOffset);
    //}

    //private void stackBuilding(Transform pParent, Vector3 pOrigin, float pGridOffset, int pX, int pZ)
    //{
    //    int height;
    //    float heightOffset = 0;
    //    if (_randomBuildingHeight)
    //        height = Random.Range(1, _maxBuildingHeight);
    //    else
    //        height = _buildingHeight;

    //    GameObject other = PrefabUtility.InstantiatePrefab(_buildingSO.BaseFloorPrefabs[Random.Range(0, _buildingSO.BaseFloorPrefabs.Count)], pParent) as GameObject;
    //    other.transform.position = new Vector3(pGridOffset * pX, pOrigin.y, pGridOffset * pZ);
    //    heightOffset += getHeightOffset(other);

    //    for (int i = 0; i < height; i++)
    //    {
    //        GameObject floor = PrefabUtility.InstantiatePrefab(_buildingSO.NormalFloorPrefabs[Random.Range(0, _buildingSO.NormalFloorPrefabs.Count)], pParent) as GameObject;
    //        floor.transform.position = new Vector3(pGridOffset * pX, heightOffset, pGridOffset * pZ);
    //        heightOffset += getHeightOffset(floor);
    //    }

    //    GameObject roof = PrefabUtility.InstantiatePrefab(_buildingSO.RoofPrefabs[Random.Range(0, _buildingSO.RoofPrefabs.Count)], pParent) as GameObject;
    //    roof.transform.position = new Vector3(pGridOffset * pX, heightOffset, pGridOffset * pZ);
    //    Debug.Log(roof.transform.position.y + "       " + heightOffset);
    //}

    //private float getHeightOffset(GameObject pFloor)
    //{
    //    Mesh mesh = pFloor.GetComponent<MeshFilter>().sharedMesh;
    //    Bounds bounds = mesh.bounds;
    //    return bounds.size.y;
    //}

    //private void deleteBuildings()
    //{
    //    if (_buildingParents.Count > 0)
    //    {
    //        foreach (GameObject other in _buildingParents)
    //            DestroyImmediate(other);

    //        _buildingParents.Clear();

    //        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    //    }
    //}
}
