using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public Transform moveToPos;
    public float speed;

    void Update()
    {
        if (transform.position != moveToPos.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, speed * Time.deltaTime);
        }
    }
}