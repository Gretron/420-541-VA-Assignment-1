using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Camera Rotation
    private Vector2 rotation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x += Input.GetAxis("Mouse X");
        rotation.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0);
    }
}
