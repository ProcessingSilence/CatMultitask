using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FireAtPlayer : StateMachineBehaviour
{
    public GameObject bullet;
    [HideInInspector] public BulletTiming BulletTiming_script;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        BulletTiming_script = animator.gameObject.AddComponent<BulletTiming>();
        BulletTiming_script.bullet = bullet;
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
        IEnumerator FireBullet()
        {
            yield return new WaitForSeconds(0.7f);
            bulletRotation = Instantiate(bullet, transform.position, quaternion.identity).transform.GetChild(0).gameObject;
        }
    }
}
