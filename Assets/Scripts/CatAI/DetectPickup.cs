using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickup : StateMachineBehaviour
{
    public float distance;
    private Transform _player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _player = GlobalObjs.ImportantObjs.player.transform;
    }

    // Detect pickup upon distance of _player & cat less than #, and _player not sitting.
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        distance = Vector2.Distance(animator.transform.position, _player.position);
        
        if (distance < .8f && Chair.IsSitting.sitCheck == false)
        {
            animator.SetBool("pickedUp", true);
            animator.SetBool("chewingWire", false);
            animator.SetBool("movingToWire", false);
        }       
    }
}
