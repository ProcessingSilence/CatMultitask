using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

// Sets up BulletTiming.cs to be used in StateMachine while giving it public variables.

// BulletTiming.cs communicates back to tell when it's attackLength is done. Goes back to idle after.

public class BulletFire : StateMachineBehaviour
{
    public string boolName;

    public GameObject bulletTimingobj;
    public GameObject currentBulletTimingObj;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        currentBulletTimingObj = Instantiate(bulletTimingobj, animator.gameObject.transform.position, Quaternion.identity);
        Debug.Log(currentBulletTimingObj);
    }

    private void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (currentBulletTimingObj.activeSelf == false)
        {
            Destroy(currentBulletTimingObj);
            animator.SetBool(boolName, false);
        }
    }
}
