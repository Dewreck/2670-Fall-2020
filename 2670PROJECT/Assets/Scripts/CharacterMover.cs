using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    public float gravity = 10f;
    public float moveSpeed = 3f;
    public float sprintMoveSpeed;
    public float jumpForce = 10f;
    public int jumpCountMax;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            movement.y = jumpForce;
        }

        if (controller.isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            movement.y -= gravity;  
        }
        
        movement.x = Input.GetAxis("Horizontal")*moveSpeed;
        controller.Move(movement*Time.deltaTime);
    }
}
