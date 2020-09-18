using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    public Vector2 randomXRange;
    public Vector2 randomYRange;
    private MyScript _MyScript_script;
    public Movement _Movement_script;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        SetVariables(animator);
        _MyScript_script.Fire();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        // Set movement position of transform object on Movement.cs
        _Movement_script.moveToPos.position = _MyScript_script.randomIdleRange;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Destroy(animator.gameObject.GetComponent<MyScript>());
    }

    public void SetVariables(Animator animator)
    {
        _Movement_script = animator.gameObject.GetComponent<Movement>();
        _MyScript_script = animator.gameObject.AddComponent<MyScript>();
        _MyScript_script.randomXRange = randomXRange;
        _MyScript_script.randomYRange = randomYRange;
    }

    public class MyScript : MonoBehaviour
    {
        public Vector2 randomXRange;
        public Vector2 randomYRange;
        public Vector2 randomIdleRange;
        public void Fire()
        {
            StartCoroutine(WaitBeforeMoving());
        }

        IEnumerator WaitBeforeMoving()
        {        
            randomIdleRange = new Vector2(
                Random.Range(randomXRange.x, randomXRange.y),
                Random.Range(randomYRange.x, randomYRange.y));
            
            yield return new WaitForSecondsRealtime(Random.Range(1f,2f));
            StartCoroutine(WaitBeforeMoving());
        }
    }
}



