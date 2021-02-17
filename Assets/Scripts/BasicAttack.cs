using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    public CharacterController controller2;
    public Animator animator;

    public float tapSpeed = 0.5f; //in seconds

    private float lastTapTime = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastTapTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
            if (Input.GetKeyDown(KeyCode.C))
        {
            if ((Time.time - lastTapTime) < tapSpeed)
            {

                animator.SetTrigger("Hit_2"); ;

            }
            else
            {
                animator.SetTrigger("Hit_1");
            }
            lastTapTime = Time.time;
        }
    }
}
