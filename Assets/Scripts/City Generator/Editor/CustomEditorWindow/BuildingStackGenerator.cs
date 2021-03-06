using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;

public class BuildingStackGenerator : EditorWindow
{
    private List<GameObject> _buildingParents = new List<GameObject>();

    private List<string> _buildingPrefabNames = new List<string>();
    private List<string> _baseFloorNames = new List<string>();
    private List<string> _floorNames = new List<string>();
    private List<string> _roofNames = new List<string>();

    private BuildingScriptableObject _buildingSO = null;

    private Vector2Int _gridSize = new Vector2Int(1, 1);

    private Vector3 _origin = Vector3.zero;

    private float _buildingOffset = 5f;

    private bool _destroyLastOnGenerate = true;
    private bool _useStackedBuildings = false;
    private bool _randomBuildingHeight = false;

    private int _buildingHeight = 1;
    private int _maxBuildingHeight = 3;
    private int _selectedBuildingInt = 0;
    private int _selectedBaseFloorInt = 0;
    private int _selectedFloorInt = 0;
    private int _selectedRoofInt = 0;
    private int _newHeight = 0;

    [MenuItem("Custom Menu/City Generator/Stack Buildings")]
    private static void init()
    {
        BuildingStackGenerator window = GetWindow<BuildingStackGenerator>("Stack City Generator");
        window.minSize = new Vector3(300, 200);
        window.maxSize = new Vector3(600, 400);
        window.Show();
    }

    private void OnEnable() => resetList();

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
                resetList();
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
                resetList();
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
            if (GUILayout.Button("Generate"))
            {
                _buildingSO.Generate(_buildingSO.BuildingPrefabs, _buildingParents);
                resetList();
            }
            EditorGUILayout.Space();
            if (GUILayout.Button("Delete All Buildings")) _buildingSO.DeleteBuildings(_buildingParents);
            EditorGUILayout.Space();
            EditorGUILayout.Space();

            if (Selection.gameObjects != null && Selection.gameObjects.Length > 0)
            {
                if (!_useStackedBuildings)
                    normalBuildingEditor();
                else
                    stackedBuildingEditor();
            }
            else
            {
                EditorGUILayout.HelpBox("You need to select a game object", MessageType.Info);
                Repaint();
            }
        }
    }

    private void stackedBuildingEditor()
    {
        GUILayout.Label("Building Customizer", EditorStyles.boldLabel);

        _newHeight = EditorGUILayout.IntField("New Building Height", _newHeight);
        foreach (GameObject obj in Selection.gameObjects)
        {

        }
        _selectedBaseFloorInt = EditorGUILayout.Popup("Base Floors", _selectedBaseFloorInt, _baseFloorNames.ToArray(), EditorStyles.popup);
        _selectedFloorInt = EditorGUILayout.Popup("Floors", _selectedFloorInt, _floorNames.ToArray(), EditorStyles.popup);
        _selectedRoofInt = EditorGUILayout.Popup("Roofs", _selectedRoofInt, _roofNames.ToArray(), EditorStyles.popup);

        if (GUILayout.Button("Apply Change")) regenerateStackedBuilding();
    }

    private void normalBuildingEditor()
    {
        GUILayout.Label("Building Customizer", EditorStyles.boldLabel);

        _selectedBuildingInt = EditorGUILayout.Popup("Buildings", _selectedBuildingInt, _buildingPrefabNames.ToArray(), EditorStyles.popup);

        EditorGUILayout.Space();
        if (GUILayout.Button("Apply Change"))
        {
            regenerateBuilding();
            Repaint();
        }
    }

    private void regenerateBuilding()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.tag == "Building" && _selectedBuildingInt <= _buildingSO.BuildingPrefabs.Count)
            {
                Vector3 newPosition = obj.transform.position;
                GameObject newObj = PrefabUtility.InstantiatePrefab(_buildingSO.BuildingPrefabs[_selectedBuildingInt], obj.transform.parent) as GameObject;
                newObj.transform.position = newPosition;
                newObj.tag = "Building";
                DestroyImmediate(obj);
            }
            else
                Debug.LogError($"{obj.name} is not a building, select an object with the Building tag");
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void regenerateStackedBuilding()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            if (obj.tag == "StackBuilding")
            {
                _buildingSO.StackBuilding(obj.transform.parent, obj.transform.position, _buildingOffset, 0, 0, _newHeight);
                DestroyImmediate(obj);
            }
            else if (obj.tag == "BaseFloor" && _selectedBaseFloorInt <= _buildingSO.BaseFloorPrefabs.Count)
            {
                GameObject newFloor = PrefabUtility.InstantiatePrefab(_buildingSO.BaseFloorPrefabs[_selectedBaseFloorInt], obj.transform.parent) as GameObject;
                newFloor.transform.position = obj.transform.position;
                newFloor.transform.rotation = obj.transform.rotation;
                newFloor.tag = obj.tag;
                DestroyImmediate(obj);
            }
            else if (obj.tag == "Floor" && _selectedFloorInt <= _buildingSO.NormalFloorPrefabs.Count)
            {
                GameObject newFloor = PrefabUtility.InstantiatePrefab(_buildingSO.NormalFloorPrefabs[_selectedFloorInt], obj.transform.parent) as GameObject;
                newFloor.transform.position = obj.transform.position;
                newFloor.transform.rotation = obj.transform.rotation;
                newFloor.tag = obj.tag;
                DestroyImmediate(obj);
            }
            else if (obj.tag == "Roof" && _selectedRoofInt <= _buildingSO.RoofPrefabs.Count)
            {
                GameObject newRoof = PrefabUtility.InstantiatePrefab(_buildingSO.NormalFloorPrefabs[_selectedRoofInt], obj.transform.parent) as GameObject;
                newRoof.transform.position = obj.transform.position;
                newRoof.transform.rotation = obj.transform.rotation;
                newRoof.tag = obj.tag;
                DestroyImmediate(obj);
            }
        }
    }

    private void resetList()
    {
        if (_buildingSO != null)
        {
            if (!_useStackedBuildings)
            {
                if (_buildingSO.BuildingPrefabs != null && _buildingSO.BuildingPrefabs.Count > 0)
                {
                    foreach (GameObject obj in _buildingSO.BuildingPrefabs)
                        _buildingPrefabNames.Add(obj.name);
                }
            }
            else
            {
                if (_buildingSO.BaseFloorPrefabs != null && _buildingSO.BaseFloorPrefabs.Count > 0)
                {
                    foreach (GameObject obj in _buildingSO.BaseFloorPrefabs)
                        _baseFloorNames.Add(obj.name);
                }
                if (_buildingSO.NormalFloorPrefabs != null && _buildingSO.NormalFloorPrefabs.Count > 0)
                {
                    foreach (GameObject obj in _buildingSO.NormalFloorPrefabs)
                        _floorNames.Add(obj.name);
                }
                if (_buildingSO.RoofPrefabs != null && _buildingSO.RoofPrefabs.Count > 0)
                {
                    foreach (GameObject obj in _buildingSO.RoofPrefabs)
                        _roofNames.Add(obj.name);
                }
            }
        }
    }
}
