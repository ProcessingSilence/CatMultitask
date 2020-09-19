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
    
    public static class GameOverVars
    {
        public static bool gameOver;
        public static bool dieInGame;
        public static bool wireKilled;
    }
    

    // Start is called before the first frame update
    void Awake()
    {
        //catAnim = GlobalObjs.ImportantObjs.cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverVars.wireKilled && GameOverVars.gameOver == false)
        {
            GameOverVars.gameOver = true;
            tvKillEffect.SetActive(true);
        }
    }
}
