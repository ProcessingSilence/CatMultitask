using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVturnoff : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(TurnOffAnimation());
    }

    IEnumerator TurnOffAnimation()
    {
        _spriteRenderer.color = new Color(255,255,255);
        yield return new WaitForSecondsRealtime(0.02f);
        _spriteRenderer.color = new Color(50,50,50);
        yield return new WaitForSecondsRealtime(0.02f);
        _spriteRenderer.color = new Color(0,0,0);
    }
}
