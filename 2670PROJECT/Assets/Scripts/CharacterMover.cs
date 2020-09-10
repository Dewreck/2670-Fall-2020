﻿
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float playerHealth = 3f, playerHealthMax = 3f, walkSpeed = 5f, sprintSpeed = 10f, rotateSpeed = 150f, gravity = -10f, jumpForce = 10.5f;
    private float yVar;

    public FloatData normalSpeed, fastSpeed, moveSpeed;
    

    public int jumpCountMax = 2;
    private int jumpCount;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = fastSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }
            var vInput = Input.GetAxis("Vertical")*moveSpeed.value;
        movement.Set(vInput,yVar,0);

        var hInput = Input.GetAxis("Horizontal")*Time.deltaTime*rotateSpeed;
        transform.Rotate(0,hInput,0);

        yVar += gravity*Time.deltaTime;

        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < jumpCountMax)
        {
            yVar = jumpForce;
            jumpCount++;
        }
        
        movement = transform.TransformDirection(movement);
        controller.Move(movement * Time.deltaTime);

        if (playerHealth > playerHealthMax)
        {
            playerHealth = playerHealthMax;
        }

        if (playerHealth < 0f)
        {
            playerHealth = 0f;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            playerHealth--;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            playerHealth++;
        }
    }
}
