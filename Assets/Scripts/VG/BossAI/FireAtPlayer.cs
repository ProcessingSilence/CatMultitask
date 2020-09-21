using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// Rotate towards the player and fire bullets at them every # seconds. 
// Reset rotation on leave.
public class FireAtPlayer : StateMachineBehaviour
{
    public GameObject bullet;
    [HideInInspector] public BulletTiming BulletTiming_script;
    public float attackLength;
    public Transform vgPlayer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        BulletTiming_script = animator.gameObject.AddComponent<BulletTiming>();
        BulletTiming_script.bullet = bullet;
        BulletTiming_script.attackLength = attackLength;
        vgPlayer = GameObject.FindWithTag("VGplayer").transform;
        BulletTiming_script.Fire();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.transform.LookAt(vgPlayer);
        if (BulletTiming_script.imDone)
        {
            animator.transform.eulerAngles = Vector3.zero;
            animator.SetBool("FireAtPlayer", false);     
        }

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        Destroy(animator.gameObject.GetComponent<BulletTiming>());
        animator.transform.localEulerAngles = Vector3.zero;
    }
    
    public class BulletTiming : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject bulletRotation;

        public float attackLength;
        
        private bool firstFireDelay;
        public bool imDone;

        public void Fire()
        {
            StartCoroutine(FireBullet());
            StartCoroutine(AttackLength());
        }

        IEnumerator FireBullet()
        {
            if (firstFireDelay == false)
            {
                firstFireDelay = true;
                yield return new WaitForSecondsRealtime(0.7f);                
            }

            bulletRotation = Instantiate(bullet, transform.position, quaternion.identity).transform.GetChild(0).gameObject;
            bulletRotation.transform.GetChild(0).GetComponent<BossBullet>().rotation = transform.eulerAngles;
            yield return new WaitForSecondsRealtime(0.7f);
            StartCoroutine(FireBullet());
        }

        IEnumerator AttackLength()
        {
            yield return new WaitForSecondsRealtime(attackLength);
        }
    }
}
