using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAtPlayer : BulletFire
{
    private Transform vgPlayer;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        vgPlayer = GameObject.FindWithTag("vgPlayer").transform;
    }

    // Update is called once per frame
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.transform.LookAt(vgPlayer);
    }
}
