using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBulletSpawner : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject FastBullet;
    public GameObject LargeBullet;
    
    private GameObject currentBullet;

    private float wait = 1.4f;

    private float wait2 = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnIteration());
        StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnIteration()
    {
        yield return new WaitForSecondsRealtime(Random.Range(wait2, wait));
        var randomLargeBullet = Random.Range(0f, 1.4f);
        if (randomLargeBullet > 1 && randomLargeBullet < 1.3)
        {
            currentBullet =
                Instantiate(LargeBullet, transform.position, Quaternion.identity);
        }
        else if (randomLargeBullet > 1.3)
        {
            currentBullet =
                Instantiate(FastBullet, transform.position, Quaternion.identity);
        }
        
        else
        {
            currentBullet =
                Instantiate(Bullet, transform.position, Quaternion.identity);
        }

        currentBullet.transform.eulerAngles = new Vector3(0, 0, Random.Range(-359f, 359f));
        StartCoroutine(SpawnIteration());
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSecondsRealtime(8f);
        {
            if (wait >= 0.8f)
            {
                wait -= 0.1f;
                wait2 -= 0.05f;
            }
            
        }
        StartCoroutine(IncreaseSpeed());
    }
}
