﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputState inputState;
    private Walk walkBehaviour;
    private Animator animator;
    private CollisionState collisionState;
    private Duck duckBehaviour;

    private void Awake()
    {
        inputState = GetComponent<InputState>();
        walkBehaviour = GetComponent<Walk>();
        animator = GetComponent<Animator>();
        collisionState = GetComponent<CollisionState>();
        duckBehaviour = GetComponent<Duck>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionState.standing)
        {
            ChangeAnimationState(0);
        }

        if(inputState.absVelX > 0)
        {
            ChangeAnimationState(1);
        }

        if(inputState.absVelY > 0)
        {
            ChangeAnimationState(2);
        }

        animator.speed = walkBehaviour.running ? walkBehaviour.runMultiploier : 1;

        if(duckBehaviour.ducking)
        {
            ChangeAnimationState(3);
        }

        if(!collisionState.standing && collisionState.onWall)
        {
            ChangeAnimationState(4);
        }

    }

    void ChangeAnimationState(int Value)
    {
        animator.SetInteger("AnimState", Value);
    }    
}
