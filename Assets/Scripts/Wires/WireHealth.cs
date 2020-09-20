using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireHealth : MonoBehaviour
{
    public float timeIteration;

    public int health;
    private int maxHealth;
    public float sparkAddIteration;
    private float divideIteration = 1.5f;

    public ParticleSystem sparks;

    public bool coroutineAllowed = true;
    private bool _catTouching;

    private GameObject catObj;

    private Transform catPos;

    public float catDistance;
    // Start is called before the first frame update
    void Awake()
    {
        sparks = transform.parent.GetChild(0).GetComponent<ParticleSystem>();
        
        maxHealth = health;
        
        catObj = GameObject.FindWithTag("Cat");
        catPos = catObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        DecideHealthLoss();
        DecideGameOver();
    }
       
    // Increase rate of spark emission based on how much health is left.
    public void SparkEmission()
    {
        var emission = sparks.emission;
        if (health == maxHealth - 1)
        {
            sparkAddIteration = 1;
        }

        else if (health > 0)
        {
            sparkAddIteration += sparkAddIteration/divideIteration;
            divideIteration -= 0.1f;
        }
        else
        {
            sparkAddIteration = 0;
        }
        emission.rateOverTime = sparkAddIteration;
    }
    
    public void DecideHealthLoss()
    {
        catDistance = Vector2.Distance(catPos.position, transform.position);
        _catTouching = catDistance < 0.01f;
        
        if (_catTouching && catObj.CompareTag("ChewingWire") && coroutineAllowed)
        {
            coroutineAllowed = false;
            StartCoroutine(HealthLossIteration());
        }
    }
    
    IEnumerator HealthLossIteration()
    {
        yield return new WaitForSecondsRealtime(timeIteration);
        if (_catTouching)
        {
            health -= 1;
            SparkEmission();
        }
        coroutineAllowed = true;
    }

    public void DecideGameOver()
    {
        if (health <= 0)
        {
            GameOverCheck.GameOverVars.wireKilled = true;
        }
    }


}
