//Made by Jeroen de Haan

using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CreateAssetMenu(fileName = "CityGenerator", menuName = "ScriptableObjects/City Generator/Normal Building")]
public class BuildingScriptableObject : ScriptableObject
{
    public List<GameObject> BuildingPrefabs = null;
    public List<GameObject> BaseFloorPrefabs = null;
    public List<GameObject> NormalFloorPrefabs = null;
    public List<GameObject> RoofPrefabs = null;
    public List<GameObject> BuildingParent = null;
    public Vector3 SpawnOrigin = Vector3.zero;
    public Vector2Int GridSize = new Vector2Int(1, 1);
    public float BuildingOffset = 1;
    public float Scale = 100f;
    public int BuildingStackHeight = 1;
    public int MaxBuildingStackHeight = 3;
    public bool DesetroyLastOnGenerate = true;
    public bool UseStackedBuildings = false;
    public bool RandomHeight = true;

    public void Generate(Vector2Int pGridSize, List<GameObject> pBuildingPrefabs, Vector3 pOrigin, float pGridOffset)
    {
        if (DesetroyLastOnGenerate) DeleteBuildings();

        GameObject emptyGameObj = new GameObject($"Generated City {pGridSize.x} X {pGridSize.y}");
        emptyGameObj.transform.position = pOrigin;
        BuildingParent.Add(emptyGameObj);

        float[,] heights = new float[GridSize.x, GridSize.y];
        heights = generateHeight();
        for (int x = 0; x < pGridSize.x; x++)
        {
            for (int z = 0; z < pGridSize.y; z++)
            {
                stackBuilding(emptyGameObj.transform, pOrigin, pGridOffset, x, z, heights);
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void stackBuilding(Transform pParent, Vector3 pOrigin, float pGridOffset, int pX, int pZ, float[,] pHeights)
    {
        int height;

        float heightOffset = 0;

        //if (RandomHeight)
        //    height = Random.Range(1, MaxBuildingStackHeight);
        //else
        //    height = BuildingStackHeight;

        height = (int)pHeights[pX, pZ];
        Debug.Log(pHeights[pX, pZ]);

        GameObject other = PrefabUtility.InstantiatePrefab(BaseFloorPrefabs[Random.Range(0, BaseFloorPrefabs.Count)], pParent) as GameObject;
        other.transform.position = new Vector3(pGridOffset * pX, pOrigin.y, pGridOffset * pZ);
        heightOffset += getHeightOffset(other);

        for (int i = 0; i < height; i++)
        {
            GameObject floor = PrefabUtility.InstantiatePrefab(NormalFloorPrefabs[Random.Range(0, NormalFloorPrefabs.Count)], pParent) as GameObject;
            floor.transform.position = new Vector3(pGridOffset * pX, heightOffset, pGridOffset * pZ);
            heightOffset += getHeightOffset(floor);
        }

        GameObject roof = PrefabUtility.InstantiatePrefab(RoofPrefabs[Random.Range(0, RoofPrefabs.Count)], pParent) as GameObject;
        roof.transform.position = new Vector3(pGridOffset * pX, heightOffset, pGridOffset * pZ);
    }

    private float getHeightOffset(GameObject pFloor)
    {
        Mesh mesh = pFloor.GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;
        return bounds.size.y;
    }

    public void DeleteBuildings()
    {
        if (BuildingParent.Count > 0)
        {
            foreach (GameObject other in BuildingParent)
                DestroyImmediate(other);

            BuildingParent.Clear();

            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }

    private float[,] generateHeight()
    {
        float[,] heights = new float[256, 256];
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 256; y++)
            {
                heights[x, y] = calculateHeight(x, y);
            }
        }
        return heights;
    }

    private float calculateHeight(int x, int y)
    {
        float xCoord = (float)x / GridSize.x * Scale;
        float yCoord = (float)y / GridSize.y * Scale;
        //Debug.Log(xCoord + "      " + yCoord);
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
