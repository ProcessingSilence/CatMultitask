using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VgPlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float horizontal, vertical;

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(horizontal,vertical) * moveSpeed;
    }

    private void OnDisable()
    {
        _rb.velocity = Vector2.zero;
    }
}
