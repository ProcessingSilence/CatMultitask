using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    public Vector2 randomRange;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    IEnumerator WaitBeforeMoving()
    {
        yield return new WaitForSecondsRealtime(Random.Range(randomRange.x, randomRange.y));
    }
}
