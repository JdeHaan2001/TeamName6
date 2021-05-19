using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToPlay : MonoBehaviour
{
    [HideInInspector] private Player _playerScript;
    [HideInInspector] private GameObject _prefab;

    private void Awake()
    {
        _playerScript = GameObject.FindGameObjectWithTag("PlayerCustomization").GetComponent<Player>();
        _prefab = _playerScript.Players[PlayerPrefs.GetInt("playerToPlay")].Looks;        
    }
    void Start()
    {
        var parentObject = Instantiate(_prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        parentObject.transform.parent = transform;
    }

}
