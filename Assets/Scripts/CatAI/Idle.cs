using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    public Transform catPos;
    public Vector2 randomXRange;
    public Vector2 randomYRange;
    private MyScript _MyScript_script;
    public Movement _Movement_script;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _Movement_script = animator.gameObject.GetComponent<Movement>();
        _MyScript_script = animator.gameObject.AddComponent<MyScript>();
        _MyScript_script.randomXRange = randomXRange;
        _MyScript_script.randomYRange = randomYRange;
        
        _MyScript_script.Fire();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _Movement_script.moveToPos.position = _MyScript_script.randomIdleRange;
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
            
            yield return new WaitForSecondsRealtime(Random.Range(1f,3f));
            StartCoroutine(WaitBeforeMoving());
        }
    }
}



