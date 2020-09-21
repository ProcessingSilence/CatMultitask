using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VgPlayerHealth : MonoBehaviour
{
    public int health;

    public bool depleteHealth;
    public bool imDead;
    
    private Rigidbody2D _rb;

    private SpriteRenderer _spriteRenderer;

    public VgPlayerMovement VgPlayerMovement_script;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MinusHealth();
        Death();
    }

    void MinusHealth()
    {
        if (depleteHealth)
        {
            depleteHealth = false;
            health -= 1;
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        if (health == 2)
        {
            _spriteRenderer.color = new Color(0.74f, 0.42f, 0.18f);
        }

        if (health == 1)
        {
            _spriteRenderer.color = new Color(0.74f, 0.56f, 0.46f);
        }

        if (health <= 0)
        {
            _spriteRenderer.color = new Color(0.74f, 0.69f, 0.71f);
        }
    }

    void Death()
    {
        if (health <= 0 && imDead == false)
        {
            imDead = true;
            Destroy(VgPlayerMovement_script);
            gameObject.GetComponent<AllowGameMovement>().enabled = false;
            
            _rb.constraints = RigidbodyConstraints2D.None;
            _rb.gravityScale = 1;
            
            _rb.AddTorque(Random.Range(-50,50), ForceMode2D.Force);
            _rb.AddForce(Vector2.right * Random.Range(-50,50));
            _rb.AddForce(Vector2.up * 350);
            GameOverCheck.GameOverVars.dieInGame = true;
        }
    }
}
