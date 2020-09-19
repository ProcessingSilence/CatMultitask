using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPickup : StateMachineBehaviour
{
    public float distance;
    public Transform player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        player = GlobalObjs.ImportantObjs.player.transform;
    }

    // Detect pickup upon distance of player & cat less than #, and player not sitting.
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        distance = Vector2.Distance(animator.transform.position, player.position);
        
        if (distance < 1f && Chair.IsSitting.sitCheck == false)
        {
            animator.SetBool("pickedUp", true);
            animator.SetBool("chewingWire", false);
        }       
    }
}
