using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        if (currentState == AnimString.asaka_punch && time >= 1)
            canExit = true;
        if (currentState == AnimString.asaka_upper && time >= 1)
            canExit = true;
        if (currentState == AnimString.asaka_bodyblow && time >= 1)
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
        transform.DOJump(transform.position, 2, 1, 1);
    }
    public void PlayPunch()
    {
        canExit = false;
        ChangeState(AnimString.asaka_punch);
    }
    public void PlayUpper()
    {
        canExit = false;
        ChangeState(AnimString.asaka_upper);
    }
    public void PlayBodyBlow()
    {
        canExit = false;
        ChangeState(AnimString.asaka_bodyblow);
    }
}
