using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndPlayer: MonoBehaviour
{
    public bool beingClickedOn;
    public bool playerTouching;

    public bool clickAndPlayer()
    {
        return playerTouching && beingClickedOn;
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

