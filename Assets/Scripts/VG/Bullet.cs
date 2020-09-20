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
    public void Start()
    {
        if (!rotateWithSpawner)
        {
            transform.localEulerAngles = rotation;
        }
    }

    public void Movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        graphics.position = transform.position;
    }

    public void OutOfBounds()
    {
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 10 || transform.position.y < -10)
        {
            kill = true;
        }
    }

    public void DestroyObj()
    {
        if (kill)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
