using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCon : MonoBehaviour
{
    private Animator animator;
    private string currentState = "asaka_idle";
    private bool canExit = true;

    // MonoCallBack
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (currentState == AnimString.asaka_jump && time >= 1)
            canExit = true;
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
        if (!canExit)
            return;
        if (value == 0f)
            ChangeState(AnimString.asaka_idle);
        else
            ChangeState(AnimString.asaka_walk);
    }

    public void PlayJump()
    {
        canExit = false;
        ChangeState(AnimString.asaka_jump);
    }
}
