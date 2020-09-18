using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDetection : ClickAndPlayer
{
    public bool beingPickedUp;

    // Update is called once per frame
    void Update()
    {
        beingPickedUp = beingClickedOn && playerTouching;
    }
}
