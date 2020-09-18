using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    private RLMovement _RlMovement_script;
    
    private bool beingClickedOn;
    private bool playerTouching;
    public bool currentlySitting;

    public Sprite[] chairSprites;

    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _RlMovement_script = playerSprite.GetComponent<RLMovement>();
    }

    void Update()
    {
        if (beingClickedOn && playerTouching)
            PlayerSitOrStand(true, 1);
    
        else
            PlayerSitOrStand(false, 0);
    }

    private void PlayerSitOrStand(bool isSitting, int spriteNum)
    {
        playerSprite.enabled = !isSitting;
        _spriteRenderer.sprite = chairSprites[spriteNum];
        currentlySitting = isSitting;
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

