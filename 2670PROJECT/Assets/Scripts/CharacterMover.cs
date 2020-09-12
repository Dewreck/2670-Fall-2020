
using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float playerHealth = 3f, playerHealthMax = 3f, walkSpeed = 5f, sprintSpeed = 10f, rotateSpeed = 150f, gravity = -10f, jumpForce = 10.5f;
    private float yVar;

    public FloatData normalSpeed, fastSpeed;
    private FloatData moveSpeed;

    public IntData playerJumpCount;
    private int jumpCount;

    public Vector3Data currentSpawnPoint;
    private void Start()
    {
        moveSpeed = normalSpeed;
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

        if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
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

    

    private void OnEnable()
    {
        //set position of the player to the location data of the player
    }
}
