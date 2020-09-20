using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move around in a random range on a random range time iteration
// Switch state upon random time range, unless infiniteIdle == true.

// Puts temporary monobehavior in gameObject for coroutine purposes until next state.
public class Idle : StateMachineBehaviour
{
    public Vector2 randomXRange;
    public Vector2 randomYRange;
    public Vector2 idleMovementWaitRange;
    public Vector2 stateTransitionWaitRange;
    
    [HideInInspector] public YieldThenNewPos _YieldThenNewPos_script;
    public Movement _movement_script;
    
    public bool infiniteIdle;

    public string nextBool;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

        SetVariables(animator);
        _YieldThenNewPos_script.Fire();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Set movement position of transform object on Movement.cs
        _movement_script.moveToPos.position = _YieldThenNewPos_script.randomIdleMovementRange;
        if (_YieldThenNewPos_script.beginTransition)
        {
            animator.SetBool(nextBool, true);
            animator.SetBool("idle", false);
            //Debug.Log("Moving to wire");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Destroy(animator.gameObject.GetComponent<YieldThenNewPos>());
    }

    // I probably could have made this more organized had I used static variables, but lack of time says it's too late.
    // This looks so ugly.
    public void SetVariables(Animator animator)
    {
        _movement_script = animator.gameObject.GetComponent<Movement>();
        _YieldThenNewPos_script = animator.gameObject.AddComponent<YieldThenNewPos>();
        if (_movement_script.enabled == false)
        {
            _movement_script.enabled = true;
        }       
        _YieldThenNewPos_script.randomXRange = randomXRange;
        _YieldThenNewPos_script.randomYRange = randomYRange;
        _YieldThenNewPos_script.beginTransition = false;
        _YieldThenNewPos_script.stateTransitionWaitRange = stateTransitionWaitRange;
        _YieldThenNewPos_script.idleMovementWaitRange = idleMovementWaitRange;
        _YieldThenNewPos_script.infiniteIdle = infiniteIdle;
    }

    public class YieldThenNewPos : MonoBehaviour
    {
        public Vector2 randomXRange;
        public Vector2 randomYRange;
        public Vector2 randomIdleMovementRange;
        public Vector2 stateTransitionWaitRange;
        public Vector2 idleMovementWaitRange;

        public bool beginTransition;
        public bool infiniteIdle;
        
        public void Fire()
        {
            StartCoroutine(WaitBeforeMoving());
            
            if (infiniteIdle == false)
            {
                StartCoroutine(WaitBeforeStateTransition());
            }
        }

        IEnumerator WaitBeforeMoving()
        {        
            randomIdleMovementRange = new Vector2(
                Random.Range(randomXRange.x, randomXRange.y),
                Random.Range(randomYRange.x, randomYRange.y));
            
            yield return new WaitForSecondsRealtime(Random.Range(idleMovementWaitRange.x,idleMovementWaitRange.y));
            StartCoroutine(WaitBeforeMoving());
        }

        IEnumerator WaitBeforeStateTransition()
        {
            yield return new WaitForSecondsRealtime(Random.Range(stateTransitionWaitRange.x,stateTransitionWaitRange.y));
            beginTransition = true;
        }
    }
}



