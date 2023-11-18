using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject rotObject;

    public TMP_Text playerText;

    private bool isGrounded;

    private int horizontalChange;
    private int verticalChange;

    public float playerNumber;
    private float moveSpeed = 50f;
    private float rotationSpeed = 500f;
    private float jumpForce = 1000f;

    private Vector3 movementInput;
    private Vector3 CustomGravity = new Vector3(0, -50, 0);

    public int pollywags;

    public static Player Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    //Singleton Workflow

    void Start()
    {
        ChangeNumber();
    }

    void Update()
    {
        if(transform.position.z < -26.5 )

        // Read player input and set rotation
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal") * horizontalChange, 0, Input.GetAxisRaw("Vertical") * verticalChange);
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
        if(rb.velocity.y < 0 || rb.velocity.y > 2)
        {
            rb.AddForce(CustomGravity, ForceMode.Acceleration);
        }
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
            var enemyFrog = col.gameObject.GetComponent<Enemy_Controller>();
            playerNumber = enemyFrog.number_identity;
            ChangeNumber();
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Quest") && !isGrounded)
        {
            Quest_Controller.Instance.GenerateEcuation();
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

    void ChangeNumber()
    {
        playerText.text = playerNumber.ToString();
    }
}