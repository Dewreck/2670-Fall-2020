using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlatformMoveBehavior : MonoBehaviour
{
    private CharacterController controller;
    public Vector3Data pos1, pos2;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    //private void Update()
    //{
        //controller.Move(pos1.value);
    //}
}
