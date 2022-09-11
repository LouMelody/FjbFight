using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCon : MonoBehaviour
{
    private Animator animator;
    private string currentState = "asaka_idle";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void ChangeState(string newState)
    {
        if (newState == currentState) return;

        animator.Play(newState);

        currentState = newState;
    }

    // ˆÈ‰ºPublic
    public void ChangeDirection(float value)
    {
        if (value == 0f)
            ChangeState(AnimString.asaka_idle);
        else
            ChangeState(AnimString.asaka_walk);
    }
}
