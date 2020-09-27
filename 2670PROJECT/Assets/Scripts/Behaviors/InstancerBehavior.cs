using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancerBehavior : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Data rotationDirection;

    public void Instance()
    {
        var location = transform.position;
        var newObj = Instantiate(prefab, location, transform.rotation);
        //Quaternion.Euler(rotationDirection.value)
    }
    
}
