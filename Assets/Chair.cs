using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    private RLMovement _RlMovement_script;
    public bool beingClickedOn;
    public bool playerTouching;

    public Sprite[] chairSprites;

    private SpriteRenderer _spriteRenderer;

    private CircleCollider2D _circleCollider2D;

    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _RlMovement_script = playerSprite.GetComponent<RLMovement>();
        _circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (beingClickedOn && playerTouching)
        {
            playerSprite.enabled = false;
            _spriteRenderer.sprite = chairSprites[1];
            
        }
        else
        {
            playerSprite.enabled = true;
            _spriteRenderer.sprite = chairSprites[0];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Clicker"))
        {
            beingClickedOn = true;
        }
        if (other.CompareTag("Player"))
        {
            playerTouching = true;
        }
    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Clicker"))
        {
            beingClickedOn = false;
        }
        if (other.CompareTag("Player"))
        {
            playerTouching = false;
        }
    }
}

