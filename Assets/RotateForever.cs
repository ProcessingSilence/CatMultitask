using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateForever : MonoBehaviour
{
    public float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,0,rotateSpeed * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
