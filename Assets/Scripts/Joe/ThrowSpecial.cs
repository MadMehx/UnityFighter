using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpecial : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject dumbellPrefab;

    public CharacterController controller4;
    public Animator animator;

    float nextAttackTime = 0f;
    //float lastTap = 0f;
    public float attackRate = 2f;
    public string idleStateName = "";

    // Start is called before the first frame update
    void Start()
    {
        int charge = 1;
        Debug.Log(charge);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                if (Input.GetKey(KeyCode.V) && controller4.isGrounded)
                {
                    Special();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }

    void Special()
    {
        Instantiate(dumbellPrefab, throwPoint.position, throwPoint.rotation, throwPoint);
        animator.SetTrigger("Curl");
    }
}
