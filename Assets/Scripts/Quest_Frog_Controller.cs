using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest_Frog_Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private float rot_Horizontal;
    private float speed = 12f;
    private float lifetime = 15f;

    public TMP_Text back_Text;
    public int number_identity = 0;


    void Start()
    {
        back_Text.text = "?";

        rb = GetComponent<Rigidbody>();

        rot_Horizontal = Random.Range(1f, 360f);
        //Generate random spawn value for frog

        float rotationAmount = rot_Horizontal;
        //Store the generated value in a variable

        transform.Rotate(Vector3.up, rotationAmount);
        //Rotate Object

        Destroy(gameObject, lifetime);
        //Kills the frog after exiting the camera

    }

    void Update()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.position += movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            // Reflect the movement direction when hitting a wall
            Vector3 reflectDirection = Vector3.Reflect(transform.forward, other.transform.forward);
            transform.forward = reflectDirection;
        }
    }
}
