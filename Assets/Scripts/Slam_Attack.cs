using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slam_Attack : MonoBehaviour
{
    public CharacterController controller3;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Do slam animation
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Running");
            if(Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Slammin");
                animator.SetTrigger("Slam");
                animator.ResetTrigger("Hit_1");
                animator.ResetTrigger("Hit_2");

            }
        }
    }


}
