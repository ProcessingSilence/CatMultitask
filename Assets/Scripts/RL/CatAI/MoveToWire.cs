using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToWire : StateMachineBehaviour
{
    public Movement _Movement_script;
    public int randomWire;
    public Vector3 wirePos;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        randomWire = Random.Range(0, 5);
        _Movement_script = animator.gameObject.GetComponent<Movement>();
        wirePos = GlobalObjs.ImportantObjs.wires[randomWire].transform.position;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _Movement_script.moveToPos.position = wirePos;
        if (animator.transform.position == wirePos)
        {
            animator.SetBool("chewingWire",  true);
            animator.SetBool("movingToWire", false);
        }
    }
}
