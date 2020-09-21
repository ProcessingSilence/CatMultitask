using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public float playerTime;
    public Text timeText;
    public Text playAgain;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = playAgain.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverCheck.GameOverVars.gameOver == false)
            playerTime = Time.time;
        else
        {
            timeText.text = "Final Time: " + playerTime;
            playAgain.text = "Press R to try again.";
        }
    }
}
