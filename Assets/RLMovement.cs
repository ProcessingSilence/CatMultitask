using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RLMovement : MonoBehaviour
{
    public Vector3 movePos;
    public float speed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            movePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movePos.z = 0;
        }
        if (transform.position != movePos)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
        }
    }
}

public class ClickPosition : RLMovement
{
    // Update is called once per frame
    void Update()
    {

    }
}