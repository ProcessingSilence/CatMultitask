using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Array containing boss attack order gets shuffled then iterated through. Reshuffles upon array iteration completion.
// This is to make it less likely for boss to repeat attacks.

// Iterates when called upon by BossIdle.cs
public class AttackOrder : MonoBehaviour
{
    public bool shuffleOrder;
    public bool arrayIterate;

    public string[] animatorBools;

    public int iterationNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shuffleOrder)
        {
            shuffleOrder = false;
            FisherYatesShuffle();
        }
    }

    // The origin of this was "https://gist.github.com/polysmurf/7393396" in 2019, but the link is dead unfortunately.
    // So you just have to take my word for this being the source.
    public void FisherYatesShuffle()
    {
        // Loops through array
        for (int i = animatorBools.Length-1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0,i);
			
            // Save the value of the current i, otherwise it will overwrite when values swapped.
            string temp = animatorBools[i];
			
            // Swap the new and old values
            animatorBools[i] = animatorBools[rnd];
            animatorBools[rnd] = temp;
        }
    }

}
