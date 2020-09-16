﻿using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ApplyForce : MonoBehaviour
{
    private Rigidbody rBody;
    public float force = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        var forceDirection = new Vector3(force,0,0);
        //forceDirection needs to be based on Player rotation (Scriptable Object)
        rBody.AddRelativeForce(forceDirection);
    }

    
}
