using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SpinAttack : BulletFire
{
    private RotateForever _current_RotateForever_script;
    public float rotateSpeed;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _current_RotateForever_script = animator.gameObject.AddComponent<RotateForever>();
        
        // Set rotate speed to randomly be positive or negative.
        _current_RotateForever_script.rotateSpeed = rotateSpeed * (Random.value < 0.5f ? 1 : -1);
    }

    private void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Destroy(_current_RotateForever_script);
    }
}
