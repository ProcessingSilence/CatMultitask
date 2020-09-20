using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingWire : StateMachineBehaviour
{
    private CircleCollider2D _circleCollider2D;
    private void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.gameObject.tag = "ChewingWire";
    }

    private void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.gameObject.tag = "Cat";
    }
}
