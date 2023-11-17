using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public Collider2D col;
    public GameObject rotObject;

    private bool isGrounded;

    private float moveSpeed = 50f;
    private float rotationSpeed = 500f;
    private float jumpForce = 500f;

    private Vector3 movementInput;

    void Update()
    {
        // Read player input and set rotation
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rotObject.transform.position = transform.position + movementInput;
        // Read player jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Move and rotate the player
        MovePlayer();
        RotatePlayer();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ground check
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        // Destroy enemy if in contact with it
        if (col.gameObject.CompareTag("Enemy") && !isGrounded)
        {
            Destroy(col.gameObject);
        }
    }

    void MovePlayer()
    {
        // Move player
        Vector3 newPosition = transform.position + movementInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    void RotatePlayer()
    {
        // Rotate the player if it isn't moving
        if (movementInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    
    void Jump()
    {
        // Set the ground check to false
        isGrounded = false;
        rb.AddForce(new Vector3(0, jumpForce, 0));
    }
}