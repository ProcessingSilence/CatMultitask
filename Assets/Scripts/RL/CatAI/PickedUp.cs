using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUp : StateMachineBehaviour
{
    private Movement _movement_script;
    
    private Transform _player;
    private Transform _chair;

    public float _chairXDistance;
    public float _chairYDistance;

    private Chair _chair_script;
    
    public Vector2 requiredLessThanDistance;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _player = GlobalObjs.ImportantObjs.player.transform;
        _chair = GlobalObjs.ImportantObjs.chair.transform;

        _chair_script = _chair.GetComponent<Chair>();
        
        _movement_script = animator.gameObject.GetComponent<Movement>();
        _movement_script.enabled = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _chairXDistance = Vector2.Distance(new Vector2(_player.position.x, 0), new Vector2(_chair.position.x, 0));
        _chairYDistance = Vector2.Distance(new Vector2(0, _player.position.y), new Vector2(0, _chair.position.y));
        
        
        // Activate being dropped upon either player reaching minimum distance of chair or by sitting in the chair.
        if ((_chairXDistance < requiredLessThanDistance.x && _chairYDistance < requiredLessThanDistance.y)
            || (_chair_script.beingClickedOn && _chair_script.playerTouching))
        {
            animator.SetBool("pickedUp",  false);
            animator.SetBool("dropped", true);
        }
        animator.transform.position = _player.position;
    }
}
