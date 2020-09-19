using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : ClickAndPlayer
{
    public SpriteRenderer playerSprite;
    private GameObject playerObj;
    private SpriteRenderer _spriteRenderer;

    public Sprite[] chairSprites;

    public static class IsSitting
    {
        public static bool sitCheck;
    }

    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        playerObj = playerSprite.gameObject;
    }

    void Update()
    {
        PlayerSitOrStand(clickAndPlayer(), clickAndPlayer() ? 1 : 0);
        IsSitting.sitCheck = clickAndPlayer();
    }

    // True: Disable player spriterenderer, change sprite to sitting
    // False: Enable player spriterenderer, change sprite to chair
    private void PlayerSitOrStand(bool isSitting, int spriteNum)
    {
        playerSprite.enabled = !isSitting;
        _spriteRenderer.sprite = chairSprites[spriteNum];
    }
}

