using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Bullet
{
    public GameObject player;

    public bool gotPlayer;
    public bool hurtPlayer;

    private VgPlayerHealth _vgPlayerHealth_script;

    // Update is called once per frame
    void Update()
    {
        DepleteHealthAndDestroy();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("VGplayer") && gotPlayer == false)
        {
            gotPlayer = true;
            player = other.gameObject;
        }
    }

    void DepleteHealthAndDestroy()
    {
        if (gotPlayer && hurtPlayer == false)
        {
            hurtPlayer = true;
            
            _vgPlayerHealth_script = player.GetComponent<VgPlayerHealth>();
            _vgPlayerHealth_script.depleteHealth = true;
            
            if (_vgPlayerHealth_script.depleteHealth)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
