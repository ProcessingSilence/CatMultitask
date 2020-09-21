using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{
    public Animator catAnim;

    public bool gameOver;
    public bool dieInGame;
    public bool wireKilled;

    public GameObject tvKillEffect;
    public GameObject videoGame;
    
    public static class GameOverVars
    {
        public static bool gameOver;
        public static bool dieInGame;
        public static bool wireKilled;
    }
    

    // For some reason getting Animator from the static gameobject variable doesn't work, even though it is clearly listed
    // in a public variable and is shown in debug.log.
    void Awake()
    {
        //catAnim = GlobalObjs.ImportantObjs.cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverVars.wireKilled && GameOverVars.gameOver == false)
        {
            tvKillEffect.SetActive(true);
            videoGame.SetActive(false);
            
            GameOverVars.gameOver = true;
           
            catAnim.SetBool("infiniteIdle", true);
        }
        if (GameOverVars.dieInGame && GameOverVars.gameOver == false)
        {
            GameOverVars.gameOver = true;
        }
    }
}
