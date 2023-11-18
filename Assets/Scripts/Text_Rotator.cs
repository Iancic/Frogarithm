using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Rotator : MonoBehaviour
{
    public Camera mainCamera;
    public float fixedSize = 1.0f;
    public Transform parentObject; // Parent object whose origin will be used

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (parentObject == null)
        {
            // If no parent object is assigned, use the parent of this GameObject
            parentObject = transform.parent;
        }
    }

    void Update()
    {
        // Set position to the parent object's origin (0, 0, 0 in local space)
        transform.position = parentObject.position + new Vector3(-1f, 2f, -2f);

        // Make the TMP face the camera
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
    }
}