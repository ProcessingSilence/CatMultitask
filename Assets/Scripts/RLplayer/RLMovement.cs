using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RLMovement : MonoBehaviour
{
    public Transform clickPos;
    public float speed;

    void Update()
    {
        if (transform.position != clickPos.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, clickPos.position, speed * Time.deltaTime);
        }
    }
}