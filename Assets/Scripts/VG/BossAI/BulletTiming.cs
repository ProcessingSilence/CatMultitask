using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTiming : MonoBehaviour
{
    public GameObject bullet;
    [HideInInspector]public GameObject bulletRotation;
    public float attackLength;
        
    private bool firstFireDelay;
    public Transform bossRotation;
    

    // Should be disabled until called upon by script. 
    void Awake()
    {
        bossRotation = GameObject.FindWithTag("Boss").transform;
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

        bulletRotation = Instantiate(bullet, transform.position, Quaternion.identity).transform.GetChild(0).gameObject;
        bulletRotation.transform.GetChild(0).GetComponent<BossBullet>().rotation = bossRotation.eulerAngles;
        
        yield return new WaitForSecondsRealtime(0.7f);
        StartCoroutine(FireBullet());
    }

    IEnumerator AttackLength()
    {
        yield return new WaitForSecondsRealtime(attackLength);
        gameObject.SetActive(false);
    }
}
