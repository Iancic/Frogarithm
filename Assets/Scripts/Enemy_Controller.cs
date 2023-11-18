using TMPro;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private float rot_Horizontal;
    private float speed = 10f;
    private float lifetime = 15f;

    public TMP_Text back_Text;
    public int number_identity = 0;

    void Start()
    {
        number_identity = Random.Range(1, 10);
        string myString = number_identity.ToString();
        back_Text.text = myString;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reflect the movement direction when hitting a wall
            Vector3 reflectDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.forward = reflectDirection;
        }
    }
}
