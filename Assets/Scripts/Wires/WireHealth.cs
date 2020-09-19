using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireHealth : MonoBehaviour
{
    public float timeIteration;

    public int health;
    private int maxHealth;

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
        SparkEmission();
        DecideHealthLoss();
        DecideGameOver();
    }
       
    // Increase rate of spark emission based on how much health is left.
    public void SparkEmission()
    {
        var emission = sparks.emission;
        emission.rateOverTime = maxHealth - health;
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
            health -= 1;
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
