using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    public Vector2 randomXRange;
    public Vector2 randomYRange;
    private YieldThenNewPos _YieldThenNewPos_script;
    public Movement _movement_script;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        SetVariables(animator);
        _YieldThenNewPos_script.Fire();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Set movement position of transform object on Movement.cs
        _movement_script.moveToPos.position = _YieldThenNewPos_script.randomIdleRange;
        if (_YieldThenNewPos_script.moveToWire)
        {
            _YieldThenNewPos_script.moveToWire = false;
            animator.SetBool("movingToWire", true);
            animator.SetBool("idle", false);
            Debug.Log("Moving to wire");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Destroy(animator.gameObject.GetComponent<YieldThenNewPos>());
    }

    public void SetVariables(Animator animator)
    {
        _movement_script = animator.gameObject.GetComponent<Movement>();
        if (_movement_script.enabled == false)
        {
            _movement_script.enabled = true;
        }
        
        _YieldThenNewPos_script = animator.gameObject.AddComponent<YieldThenNewPos>();
        _YieldThenNewPos_script.randomXRange = randomXRange;
        _YieldThenNewPos_script.randomYRange = randomYRange;
    }

    public class YieldThenNewPos : MonoBehaviour
    {
        public Vector2 randomXRange;
        public Vector2 randomYRange;
        public Vector2 randomIdleRange;

        public bool moveToWire;
        public void Fire()
        {
            StartCoroutine(WaitBeforeMoving());
            StartCoroutine(WaitBeforeMovingToWire());
        }

        IEnumerator WaitBeforeMoving()
        {        
            randomIdleRange = new Vector2(
                Random.Range(randomXRange.x, randomXRange.y),
                Random.Range(randomYRange.x, randomYRange.y));
            
            yield return new WaitForSecondsRealtime(Random.Range(1f,2f));
            StartCoroutine(WaitBeforeMoving());
        }

        IEnumerator WaitBeforeMovingToWire()
        {
            yield return new WaitForSecondsRealtime(Random.Range(1f,10f));
            moveToWire = true;
        }

    }
}



