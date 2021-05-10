//Made by Jeroen de haan

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildingStacker : MonoBehaviour
{
    public bool GenerateOnEnable;

    [SerializeField][Range(1, 10)]
    private int minFloors = 3;
    [SerializeField][Range(1, 100)]
    private int maxFloors = 5;

    private const int spawnAmount = 4;
    

    public List<GameObject> GroundFloors;
    public List<GameObject> NormalFloors;
    public List<GameObject> Roofs;
    // TODO: Make this list editable in runtime and when generate is clicked that list is generated
    public List<GameObject> BuildingLayout;

    private void OnEnable()
    {
        if (GenerateOnEnable)
        {
            Generate();
        }
    }

    public void Generate()
    {
        if (BuildingLayout.Count > 0)
        {
            foreach (GameObject other in BuildingLayout)
            {
                Destroy(other);
            }
            BuildingLayout.Clear();
        }
        int buildingHeight = Random.Range(minFloors, maxFloors);
        float HeightOffset = 0;
        HeightOffset += BuildFloor(GroundFloors, HeightOffset);

        for (int i = 2; i < buildingHeight; i++)
        {
            HeightOffset += BuildFloor(NormalFloors, HeightOffset);
        }

        BuildFloor(Roofs, HeightOffset);
    }

    private float BuildFloor(List<GameObject> pFloorList, float pHeightOffSet)
    {
        Transform randomFloor = pFloorList[Random.Range(0, pFloorList.Count)].transform;
        //GameObject other = Instantiate(randomFloor.gameObject, this.transform.position + new Vector3(0, HeightOffset, 0),
        //                   transform.rotation) as GameObject;
        GameObject other = PrefabUtility.InstantiatePrefab(randomFloor.gameObject) as GameObject;
        other.transform.position = this.transform.position + new Vector3(0, pHeightOffSet, 0);
        other.transform.rotation = this.transform.rotation;

        Mesh otherMesh = other.GetComponentInChildren<MeshFilter>().mesh;
        Bounds bounds = otherMesh.bounds;
        //float heightOffset = bounds.size.y;
        float heightOffset = other.transform.position.y;

        other.transform.SetParent(this.transform);
        //BuildingLayout.Add(other);
        return heightOffset;
    }
}
