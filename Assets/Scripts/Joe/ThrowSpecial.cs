using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpecial : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject dumbellPrefab;

    public CharacterController controller4;
    public Animator animator;

    public string idleStateName = "";
    public int charge;

    bool justPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.V) && charge > 0)
        {
            ActualThrow(charge);//calls to throw the object
            charge = 0;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && !Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.V) && controller4.isGrounded)
            {
                if (!justPressed)
                {
                    Instantiate(dumbellPrefab, throwPoint.position, throwPoint.rotation, throwPoint);
                }
                animator.SetBool("Curling", true);
                justPressed = true;
            }
            else
            {
                animator.SetBool("Curling", false);
                justPressed = false;
            }
        }
        else
        {
            animator.SetBool("Curling", false);
            justPressed = false;
        }
    }

    public void Joe_Charge_Up()
    {
        charge++;
    }

    void ActualThrow(int chargeLevel)
    {
        //calls animator to perform throw
        animator.SetTrigger("Throw");

        //creates game object
        Instantiate(dumbellPrefab, throwPoint.position, throwPoint.rotation, throwPoint);
    }
}
