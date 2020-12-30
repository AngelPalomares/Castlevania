using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : AbstractBehaviour
{
    public float jumpSpeed = 200f;
    public float JumpDelay = .1f;
    public int jumpCount = 2;
    public GameObject DustEffect;

    protected float lastJumpTime = 0;
    protected int jumpsRemaining = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        var canJump = inputState.GetButtonValue(InputButtons[0]);
        var HoldTime = inputState.GetButtonHoldTime(InputButtons[0]);

        if (collisionState.standing)
        {
            if (canJump && HoldTime < .1f)
            {
                jumpsRemaining = jumpCount - 1;
                OnJump();
            }
        }
        else
        {
           if (canJump && HoldTime < .1f && Time.time - lastJumpTime > JumpDelay)
           {
                if (jumpsRemaining > 0)
                {
                    OnJump();
                    jumpsRemaining--;
                    var clone = Instantiate(DustEffect);
                    clone.transform.position = transform.position;
                }
           }
        }
    }
    protected virtual void OnJump()
    {
        var Vel = body2d.velocity;
        lastJumpTime = Time.time;
        body2d.velocity = new Vector2(Vel.x, jumpSpeed);
    }
}
