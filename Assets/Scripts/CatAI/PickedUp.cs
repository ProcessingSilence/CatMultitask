using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : StateMachineBehaviour
{
    private Movement _movement_script;
    private Transform player;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _movement_script = animator.gameObject.GetComponent<Movement>();
        _movement_script.enabled = false;
        

        player = GameObject.FindWithTag("Player").transform;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.transform.position = player.position;
    }
}
