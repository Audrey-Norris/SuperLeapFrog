using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{        public float speed = 5f;  // Adjust this to set the movement speed.
    public float rotationSpeed = 100f;  // Adjust this to set the rotation speed.
    public float jumpForce = 5f;  // Adjust this to set the jump force.
    public bool isGrounded;  // Track whether the player is grounded.

    void Update()
    {
        // Get input from the A and D keys for rotation.
        float horizontalInput = Input.GetAxis("Player2Horizontal");

        // Calculate the rotation angle based on the input in local space.
        float rotationAngle = horizontalInput * rotationSpeed * Time.deltaTime;
        Vector3 localRotation = transform.TransformDirection(Vector3.up) * rotationAngle;

        // Rotate the character based on the local input.
        transform.Rotate(localRotation, Space.World);

        // Get input from the W key for forward movement.
        float verticalInput = Input.GetAxis("Player2Vertical");

        // Only move if the input is positive (W key or joystick up).
        if (verticalInput > 0)
        {
            // Calculate the movement direction in local space.
            Vector3 localMovement = transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime;

            // Move the character based on the local input.
            transform.Translate(localMovement, Space.World);
        }

        // Check for jump input (space key) and if the player is grounded.
        if (Input.GetButtonDown("Player2Jump") && isGrounded)
        {
            // Apply an upward force to simulate jumping.
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Set isGrounded to false to prevent double jumping.
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded when colliding with a surface.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Check if the player is grounded when no longer colliding with a surface.
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
