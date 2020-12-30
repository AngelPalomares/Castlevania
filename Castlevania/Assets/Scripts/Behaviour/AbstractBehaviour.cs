using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBehaviour : MonoBehaviour
{
    public Buttons[] InputButtons;
    public MonoBehaviour[] dissabledScripts;

    

    protected InputState inputState;
    protected Rigidbody2D body2d;
    protected CollisionState collisionState;

    protected virtual void Awake()
    {
        inputState = GetComponent<InputState>();
        body2d = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
    }

    protected virtual void ToggleScripts(bool value)
    {
        foreach(var script in dissabledScripts)
        {
            script.enabled = value;
        }    
    }
}
