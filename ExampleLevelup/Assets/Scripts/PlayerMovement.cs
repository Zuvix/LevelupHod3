using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed=12f;
    Vector3 velocity;
    public float gravity = -10f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 motion = transform.right * x + transform.forward * z;
        controller.Move(motion *speed*Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        if (isGrounded &&velocity.y<0f)
        {
            velocity.y = -1f;
        }
        controller.Move(velocity * Time.deltaTime);

    }
}
