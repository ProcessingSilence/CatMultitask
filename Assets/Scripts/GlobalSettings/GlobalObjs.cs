using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjs : MonoBehaviour
{
    public GameObject player, cat, chair, vgPlayer, boss;
    public GameObject[] wiresPos;
    
    public static class ImportantObjs
    {
        public static GameObject player, cat, chair, vgPlayer, boss;
        public static GameObject[] wires;
    }

    // Start is called before the first frame update
    void Awake()
    {
        ImportantObjs.player = player;
        Debug.Log("player: " + player);
        
        ImportantObjs.cat = cat;
        Debug.Log("cat: " + cat);
        
        ImportantObjs.chair = chair;
        Debug.Log("chair: " + chair);        
        
        ImportantObjs.vgPlayer = vgPlayer;
        Debug.Log("vgPlayer: " + vgPlayer);
                
        ImportantObjs.boss = boss;
        Debug.Log("boss: " + boss);
        
        ImportantObjs.wires = wiresPos;
        for (int i = 0; i < ImportantObjs.wires.Length; i++)
        {
            Debug.Log(ImportantObjs.wires[i].transform.position);
        }

        Debug.Log(ImportantObjs.wires.Length);
    }

}
