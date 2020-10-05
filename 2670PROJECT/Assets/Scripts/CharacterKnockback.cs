using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(CharacterController))]
public class CharacterKnockback : MonoBehaviour
{
    private CharacterController controller;
    
    public Vector3 move;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    

    //private IEnumerator KnockBack (Collider other)
   // {
        //var i = 2f;
        //move = hit.collider
    //}

    public float pushPower = 10f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
        
        //var pushDir = new Vector3(hit.moveDirection);
    }
}
