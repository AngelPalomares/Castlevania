using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : AbstractBehaviour
{
    public float scare = .5f;
    public bool ducking;
    public float CenterOffset = 0f;

    private CircleCollider2D circleCollider;
    private Vector2 originalCenter;

    protected override void Awake()
    {
        base.Awake();

        circleCollider = GetComponent<CircleCollider2D>();
        originalCenter = circleCollider.offset;

    }

    protected virtual void onDuck(bool value)
    {
        ducking = value;

        ToggleScripts(!ducking);

        var size = circleCollider.radius;

        float newoffsetY;
        float sizeReciprocal;

        if(ducking)
        {
            sizeReciprocal = scare;
            newoffsetY = circleCollider.offset.y - size / 2 + CenterOffset;
        }
        else
        {
            sizeReciprocal = 1 / scare;
            newoffsetY = originalCenter.y;
        }

        size = size * sizeReciprocal;
        circleCollider.radius = size;
        circleCollider.offset = new Vector2(circleCollider.offset.x, newoffsetY);

    }

    // Update is called once per frame
    void Update()
    {
        var canDuck = inputState.GetButtonValue(InputButtons[0]);
        if(canDuck && collisionState.standing && !ducking)
        {
            onDuck(true);
        }else if(ducking && !canDuck)
        {
            onDuck(false);
        }
    }
}
