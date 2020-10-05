
using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;

    public float walkSpeed = 5f, sprintSpeed = 10f, rotateSpeed = 150f, gravity = -10f, jumpForce = 10.5f;
    private float yVar;

    public FloatData normalSpeed, fastSpeed;
    private FloatData moveSpeed;

    public IntData playerJumpCount;
    private int jumpCount;

    public Vector3Data currentSpawnPoint;

    public GameObject player;
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

        var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        var hInput = Input.GetAxis("Horizontal") * moveSpeed.value;
        movement.Set(hInput, yVar, vInput);

        //var hInput = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        //transform.Rotate(0, hInput, 0);

        yVar += gravity * Time.deltaTime;

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
    }

    private Vector3 direction = Vector3.zero;
    public float pushPower = 3f;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        if (body == null)
        {
            return;
        }

        direction.Set(hit.moveDirection.x,0, hit.moveDirection.z);
        var pushDirection = direction * pushPower;
        body.velocity = pushDirection;
    }
}
