using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// How this cycle works: https://drive.google.com/file/d/1STBBOAivKVt9JFnuxOwwFJcpf6qvqWpe/view?usp=sharing
public class ChooseAttack : MonoBehaviour
{
    public Animator stateMachine;
    
    private AttackOrder AttackOrder_script;

    public int iterationNum;

    public Vector2 idleTimeRange;

    public bool attackActivated;
    
    // Ensure that if check on animator bool doesn't repeat.
    public bool imDone;

    public string[] animatorBoolNames;

    void Awake()
    {
        AttackOrder_script = GetComponent<AttackOrder>();
        AttackOrder_script.FisherYatesShuffle();
        animatorBoolNames = AttackOrder_script.animatorBoolNames;
        
        StartCoroutine(IdleTimeBeforeAttack());
    }

    void Update()
    {
        Iterate();
    }

    IEnumerator IdleTimeBeforeAttack()
    {
        yield return new WaitForSecondsRealtime(Random.Range(idleTimeRange.x, idleTimeRange.y));
        SetAttack();
    } 
    
    public void SetAttack()
    {
        if (attackActivated == false)
        {
            attackActivated = true;
            imDone = false;
            
            stateMachine.SetBool(animatorBoolNames[iterationNum], true);
            
            Debug.Log("Chosen bool: " + animatorBoolNames[iterationNum]);
        }
    }

    public void Iterate()
    {
        // imDone gets called from current statemachine attack
        if (stateMachine.GetBool(animatorBoolNames[iterationNum]) == false && imDone == false)
        {
            imDone = true;
            
            iterationNum++;
            
            if (iterationNum > animatorBoolNames.Length)
            {
                ResetBoolListOrder();
            }

            attackActivated = false;
            StartCoroutine(IdleTimeBeforeAttack());
        }
    }

    public void ResetBoolListOrder()
    {
        AttackOrder_script.FisherYatesShuffle();
        iterationNum = 0;
        animatorBoolNames = AttackOrder_script.animatorBoolNames;
    }
}
