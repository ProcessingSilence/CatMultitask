using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPos : MonoBehaviour
{
    // Set to player position to prevent player from moving without mouse input.
    void Awake()
    {
        transform.position = GameObject.FindWithTag("Player").transform.position;
    }

    private Vector3 clickPos;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            // Prevent click position from going above the floor.
            if (clickPos.y > 4.7)
                transform.position = new Vector3(clickPos.x, 4.7f, 0);
            else
                transform.position = new Vector3(clickPos.x, clickPos.y, 0);
        }
    }
}
