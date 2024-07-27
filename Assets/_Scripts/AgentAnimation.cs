using System;
using UnityEngine;

public class AgentAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(AnimationType animationType)
    {
        switch (animationType)
        {
            case AnimationType.idle:
                Play("Idle");
                break;
            case AnimationType.run:
                Play("Run");
                break;
            case AnimationType.jump:
                Play("Jump");
                break;
            case AnimationType.fall:
                Play("Fall");
                break;
            case AnimationType.climb:
                Play("Climbing");
                break;
            default:
                break;
        }

    }

    public void Play(string name)
    {
        animator.Play(name, -1, 0f);
    }

    internal void StopAnimation()
    {
        animator.enabled = false;
    }
    internal void StartAnimation()
    {
        animator.enabled = true;
    }
}

public enum AnimationType
{
    idle,
    run,
    jump,
    fall,
    climb,
    attack,
    die,
    hit,
    land
}
