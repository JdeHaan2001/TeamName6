//Made by Jeroen de haan

using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField][Range(1, 20)]
    private int gridSizeX = 2;
    [SerializeField][Range(1, 20)]
    private int gridSizeZ = 2;

    private List<GameObject> buildingList = new List<GameObject>();

    public GameObject building;
    public Vector3 gridOrigin = Vector3.zero;
    public float gridOffset = 5f;
    public bool generateOnEnable;

    private void OnEnable()
    {
        if (generateOnEnable)
            GenerateGrid();
    }

    public void GenerateGrid()
    {
        if (buildingList.Count > 0)
        {
            foreach (GameObject other in buildingList)
            {
                Destroy(other);
            }
            buildingList.Clear();
        }
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                GameObject other = Instantiate(building, this.transform.position + gridOrigin + new Vector3(gridOffset * x, 0f, gridOffset * z)
                    , this.transform.rotation);
                other.transform.SetParent(this.transform);
                buildingList.Add(other);
            }
        }
    }
}
