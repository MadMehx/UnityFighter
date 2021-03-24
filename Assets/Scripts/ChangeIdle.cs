using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIdle : MonoBehaviour
{
    public AnimationClip hurtIdle;
    public AnimationClip death;

    protected Animator animator;
    protected AnimatorOverrideController animatorOverrideController;

    public int healthToHurt = 40;
    public string animationName = "";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<HealthScript>().getHealth() <= healthToHurt)
        {
            animatorOverrideController[animationName] = hurtIdle;
        }
        else if (this.GetComponent<HealthScript>().getHealth() <= 0)
        {
            animatorOverrideController[animationName] = death;
        }
    }
}
