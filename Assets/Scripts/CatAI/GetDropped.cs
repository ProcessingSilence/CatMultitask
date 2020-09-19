using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDropped : StateMachineBehaviour
{
    public float speed;
    private float yPos;
    private Rigidbody2D _rb2D;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _rb2D = animator.gameObject.GetComponent<Rigidbody2D>();
        yPos = animator.gameObject.transform.position.y - .5f;
        _rb2D.velocity = new Vector2(0,-speed);
    }

    // Update is called once per frame
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (animator.transform.position.y <= yPos)
        {
            _rb2D.velocity = Vector2.zero;
            animator.gameObject.GetComponent<Movement>().enabled = true;
            animator.SetBool("dropped", false);
            animator.SetBool("idle", true);
        }
    }
}
