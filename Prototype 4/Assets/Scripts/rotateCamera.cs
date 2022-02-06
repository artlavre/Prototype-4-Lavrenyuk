using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    private float rotationSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput  = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotationSpeed);
    }
}
