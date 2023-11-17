using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private float rot_Horizontal;
    private float speed = 20f;
    private float lifetime = 15f;

    void Start()
    {
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
}
