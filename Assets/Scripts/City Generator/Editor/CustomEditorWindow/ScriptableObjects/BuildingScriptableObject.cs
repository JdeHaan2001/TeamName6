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

    public void Generate(List<GameObject> pBuildingPrefabs, List<GameObject> pBuildingParents)
    {
        if (DesetroyLastOnGenerate) DeleteBuildings(pBuildingParents);

        GameObject emptyGameObj = new GameObject($"Generated City {GridSize.x} X {GridSize.y}");
        emptyGameObj.transform.position = SpawnOrigin;
        pBuildingParents.Add(emptyGameObj);

        for (int x = 0; x < GridSize.x; x++)
        {
            for (int z = 0; z < GridSize.y; z++)
            {
                if (UseStackedBuildings)
                    stackBuilding(emptyGameObj.transform, SpawnOrigin, BuildingOffset, x, z);
                else
                    spawnBuildings(emptyGameObj.transform, x, z);
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void spawnBuildings(Transform pParent, int pX, int pZ)
    {
        int randomIndex = Random.Range(0, BuildingPrefabs.Count);
        GameObject building = PrefabUtility.InstantiatePrefab(BuildingPrefabs[randomIndex], pParent) as GameObject;
        building.transform.position = new Vector3(pX * BuildingOffset, SpawnOrigin.y, pZ * BuildingOffset);
    }

    private void stackBuilding(Transform pParent, Vector3 pOrigin, float pGridOffset, int pX, int pZ)
    {
        int height;
        float heightOffset = 0;
        if (RandomHeight)
            height = Random.Range(1, MaxBuildingStackHeight);
        else
            height = BuildingStackHeight;

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
        Debug.Log(roof.transform.position.y + "       " + heightOffset);
    }

    private float getHeightOffset(GameObject pFloor)
    {
        Mesh mesh = pFloor.GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;
        return bounds.size.y;
    }

    public void DeleteBuildings(List<GameObject> pBuildingParents)
    {
        if (pBuildingParents.Count > 0)
        {
            foreach (GameObject other in pBuildingParents)
                DestroyImmediate(other);

            pBuildingParents.Clear();

            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
    }
    /*public void Generate(Vector2Int pGridSize, List<GameObject> pBuildingPrefabs, Vector3 pOrigin, float pGridOffset)
    {
        if (DesetroyLastOnGenerate) DeleteBuildings();

        GameObject emptyGameObj = new GameObject($"Generated City {pGridSize.x} X {pGridSize.y}");
        emptyGameObj.transform.position = pOrigin;
        BuildingParent.Add(emptyGameObj);

        for (int x = 0; x < pGridSize.x; x++)
        {
            for (int z = 0; z < pGridSize.y; z++)
            {
                stackBuilding(emptyGameObj.transform, pOrigin, pGridOffset, x, z);
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void stackBuilding(Transform pParent, Vector3 pOrigin, float pGridOffset, int pX, int pZ)
    {
        GameObject emptyGameObj = new GameObject($"Building");
        emptyGameObj.transform.position = pOrigin;
        emptyGameObj.transform.SetParent(pParent);
        BuildingParent.Add(emptyGameObj);

        int height;

        float heightOffset = 0;

        if (RandomHeight)
            height = Random.Range(1, MaxBuildingStackHeight);
        else
            height = BuildingStackHeight;

        GameObject other = PrefabUtility.InstantiatePrefab(BaseFloorPrefabs[Random.Range(0, BaseFloorPrefabs.Count)], emptyGameObj.transform) as GameObject;
        other.transform.position = new Vector3(pGridOffset * pX, pOrigin.y, pGridOffset * pZ);
        heightOffset += getHeightOffset(other);

        for (int i = 0; i < height; i++)
        {
            GameObject floor = PrefabUtility.InstantiatePrefab(NormalFloorPrefabs[Random.Range(0, NormalFloorPrefabs.Count)], emptyGameObj.transform) as GameObject;
            floor.transform.position = new Vector3(pGridOffset * pX, heightOffset, pGridOffset * pZ);
            heightOffset += getHeightOffset(floor);
        }

        GameObject roof = PrefabUtility.InstantiatePrefab(RoofPrefabs[Random.Range(0, RoofPrefabs.Count)], emptyGameObj.transform) as GameObject;
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
    }*/
}
