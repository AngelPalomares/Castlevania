﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState
{
    public bool value;
    public float holdTime = 0;
}

public enum Direction
{
    Right = 1, Left = -1
}

public class InputState : MonoBehaviour
{
    public Direction direction = Direction.Right;
    public float absVelX = 0f;
    public float absVelY = 0f;


    private Rigidbody2D body2D;
    private Dictionary<Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState>();


    private void Awake()
    {
        body2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        absVelX = Mathf.Abs(body2D.velocity.x);
        absVelY = Mathf.Abs(body2D.velocity.y);
    }

    public void SetButtonValue(Buttons key, bool value)
    {
        if(!buttonStates.ContainsKey(key))
        {
            buttonStates.Add(key, new ButtonState());
        }

        var state = buttonStates[key];

        if (state.value && !value)
        {
            state.holdTime = 0;
        }
        else if (state.value && value)
            state.holdTime += Time.deltaTime;


        state.value = value;
    }

    public bool GetButtonValue(Buttons key)
    {
        if (buttonStates.ContainsKey(key))
        {
            return buttonStates[key].value;
        }
        else
            return false;
    }

    public float GetButtonHoldTime(Buttons key)
    {
        if (buttonStates.ContainsKey(key))
        {
            return buttonStates[key].holdTime;
        }
        else
            return 0;
    }
}
