using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CityGenerator", menuName = "ScriptableObjects/City Generator")]
public class BuildingScriptableObject : ScriptableObject
{
    public List<GameObject> BuildingPrefabs;
}
