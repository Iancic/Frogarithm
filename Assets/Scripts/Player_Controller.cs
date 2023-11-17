using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject rotObject;
    private float moveSpeed = 50f;
    private float rotationSpeed = 500f;
    private Vector3 movementInput;

    void Update()
    {
        // Read input in Update
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rotObject.transform.position = transform.position + movementInput;
    }

    void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        Vector3 newPosition = transform.position + movementInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    void RotatePlayer()
    {
        if (movementInput != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}