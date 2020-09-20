using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    
    public Vector3 rotation;

    public bool rotateWithSpawner;
    public Transform graphics;

    [HideInInspector] public bool kill;
    // Start is called before the first frame update
    void Start()
    {
        if (!rotateWithSpawner)
        {
            transform.localEulerAngles = rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBounds();
        DestroyObj();
    }

    void Movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        graphics.position = transform.position;
    }

    void OutOfBounds()
    {
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 10 || transform.position.y < -10)
        {
            kill = true;
        }
    }

    void DestroyObj()
    {
        if (kill)
        {
            Destroy(gameObject);
        }
    }
}
