//Made by Jeroen de Haan

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CityGenerator", menuName = "ScriptableObjects/City Generator")]
public class BuildingScriptableObject : ScriptableObject
{
    public List<GameObject> BuildingPrefabs = null;
    public Vector3 SpawnOrigin = Vector3.zero;
    public Vector2Int GridSize = new Vector2Int(1, 1);
    public float BuildingOffset = 1;
    public bool DesetroyLastOnGenerate = true;

}
