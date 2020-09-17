﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    public GameObject playerObj;
    private RLMovement _RlMovement_script;
    private bool inChairFlag;
    private bool leavingChairFlag;

    public Sprite[] chairSprites;
    
    public SpriteRenderer _SpriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _RlMovement_script = playerObj.GetComponent<RLMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (inChairFlag == false && other.CompareTag("Player"))
        {
            inChairFlag = true;
            PutPlayerInChair();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        throw new System.NotImplementedException();
    }

    void PutPlayerInChair()
    {
        playerObj.SetActive(false);
        _SpriteRenderer.sprite = chairSprites[1];
    }
}
