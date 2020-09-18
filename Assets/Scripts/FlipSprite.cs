using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public Transform movementPos;

    private Vector3 prevPos;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPos.position != prevPos)
        {
            prevPos = movementPos.position;
            _spriteRenderer.flipX = transform.position.x < prevPos.x;
        }
    }
}
