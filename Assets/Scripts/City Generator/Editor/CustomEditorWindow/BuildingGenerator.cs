using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

public class BuildingGenerator : ScriptableObject
{
    public List<GameObject> BuildingPrefabs = null;
    public List<GameObject> BaseFloorPrefabs = null;
    public List<GameObject> NormalFloorPrefabs = null;
    public List<GameObject> RoofPrefabs = null;
    public List<GameObject> BuildingParent = null;
    public Vector3 SpawnOrigin = Vector3.zero;
    public Vector2Int GridSize = new Vector2Int(1, 1);
    public float BuildingOffset = 1;
    public int BuildingStackHeight = 1;
    public int MaxBuildingStackHeight = 3;
    public bool DesetroyLastOnGenerate = true;
    public bool UseStackedBuildings = false;
    public bool RandomHeight = true;




}
