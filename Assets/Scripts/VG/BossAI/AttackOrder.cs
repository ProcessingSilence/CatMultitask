using UnityEngine;

// Array containing boss attack order gets shuffled then iterated through.
// This is to make the boss less likely for boss to repeat attacks.
public class AttackOrder : MonoBehaviour
{
    public string[] animatorBoolNames;

    // The origin of this was "https://gist.github.com/polysmurf/7393396" in 2019, but the link is dead unfortunately.
    // So you just have to take my word for this being the source.
    public void FisherYatesShuffle()
    {
        // Loops through array
        for (int i = animatorBoolNames.Length-1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0,i);
			
            // Save the value of the current i, otherwise it will overwrite when values swapped.
            string temp = animatorBoolNames[i];
			
            // Swap the new and old values
            animatorBoolNames[i] = animatorBoolNames[rnd];
            animatorBoolNames[rnd] = temp;
        }
    }
}
