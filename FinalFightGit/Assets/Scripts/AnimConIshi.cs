using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimConIshi : MonoBehaviour
{
    private Animator animator;
    private string currentState = "ishikawa_idle";
    private bool canExit = true;

    // MonoCallBack
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        float time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (currentState == AnimString.ishikawa_jump && time >= 1)
            canExit = true;
        if (currentState == AnimString.ishikawa_punch && time >= 1)
            canExit = true;
        if (currentState == AnimString.ishikawa_upper && time >= 1)
            canExit = true;
        if (currentState == AnimString.ishikawa_bodyblow && time >= 1)
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
            ChangeState(AnimString.ishikawa_idle);
        else
            ChangeState(AnimString.ishikawa_walk);
    }

    public void PlayJump()
    {
        canExit = false;
        ChangeState(AnimString.ishikawa_jump);
        transform.DOJump(transform.position, 2, 1, 1);
    }
    public void PlayPunch()
    {
        canExit = false;
        ChangeState(AnimString.ishikawa_punch);
    }
    public void PlayUpper()
    {
        canExit = false;
        ChangeState(AnimString.ishikawa_upper);
    }
    public void PlayBodyBlow()
    {
        canExit = false;
        ChangeState(AnimString.ishikawa_bodyblow);
    }
}
