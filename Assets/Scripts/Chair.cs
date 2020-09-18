using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : ClickAndPlayer
{
    public SpriteRenderer playerSprite;
    private SpriteRenderer _spriteRenderer;

    public Sprite[] chairSprites;


    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerSitOrStand(clickAndPlayer(), clickAndPlayer() ? 1 : 0);
    }

    private void PlayerSitOrStand(bool isSitting, int spriteNum)
    {
        playerSprite.enabled = !isSitting;
        _spriteRenderer.sprite = chairSprites[spriteNum];
    }
}

