using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void AnimationPlay()
    {
        animator.SetBool("animationPlay", true);
    }
    void AnimationEnd()
    {
        transform.position = new Vector3(0f, -7.5f, 0f);
        animator.SetBool("animationPlay", false);
    }
}
