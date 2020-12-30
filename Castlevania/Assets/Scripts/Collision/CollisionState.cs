using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour
{
    public LayerMask CollisionLayer;
    public bool standing;
    public bool onWall;

    public Vector2 bottomPosition = Vector2.zero;
    public Vector2 RightPosition = Vector2.zero;
    public Vector2 LeftPosition = Vector2.zero;

    public float CollisionRadius = 10f;
    public Color DebugCollisionColor = Color.red;


    private InputState inputState;


    // Start is called before the first frame update
    void Start()
    {
        inputState = GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        var pos = bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        standing = Physics2D.OverlapCircle(pos, CollisionRadius, CollisionLayer);

        pos = inputState.direction == Direction.Right ? RightPosition: LeftPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        onWall = Physics2D.OverlapCircle(pos, CollisionRadius, CollisionLayer);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = DebugCollisionColor;

        var positions = new Vector2[] { RightPosition, bottomPosition, LeftPosition };
        foreach (var position in positions)
        {
            var pos = position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;

            Gizmos.DrawWireSphere(pos, CollisionRadius);
        }
    }
}
