using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingPlayerFollower : MonoBehaviour
{
    private GameObject _objectToFollow;

    public float speed = 2.0f;
    void Update()
    {
        _objectToFollow = GameObject.FindWithTag("PlayerCharacter");

        float interpolation = speed * Time.deltaTime;
        if(_objectToFollow != null)
        {
            //Vector3 position = this.transform.position;
            //position.y = Mathf.Lerp(this.transform.position.y, _objectToFollow.transform.position.y, interpolation);
            //position.x = Mathf.Lerp(this.transform.position.x, _objectToFollow.transform.position.x, interpolation);
            //position.z = Mathf.Lerp(this.transform.position.z, _objectToFollow.transform.position.z - 10, interpolation);

            this.transform.LookAt(_objectToFollow.transform);
        }        
    }
}
