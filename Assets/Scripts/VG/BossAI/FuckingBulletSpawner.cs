using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckingBulletSpawner : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject FastBullet;
    public GameObject LargeBullet;
    
    private GameObject currentBullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnIteration());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnIteration()
    {
        yield return new WaitForSecondsRealtime(Random.Range(1f, 1.4f));
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
}
