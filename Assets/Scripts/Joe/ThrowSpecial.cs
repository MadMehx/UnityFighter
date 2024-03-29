﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpecial : MonoBehaviour
{
    public Transform dumbbellThrowPoint;
    public Transform barbellThrowPoint;
    public GameObject dumbellPrefab;
    public GameObject barbellPrefab;

    public CharacterController controller4;
    public Animator animator;

    public string idleStateName = "";
    public int charge;

    GameObject weight;

    bool justPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        charge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.V) && charge > 0) //must have V and down pressed down
        {
            ActualThrow();//calls to throw the object
            charge = 0;
        }
        else if (Input.GetAxisRaw("Horizontal") == 0 && !Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.V) && controller4.isGrounded)
            {
                if (!justPressed)
                {
                    weight = (GameObject)Instantiate(dumbellPrefab, dumbbellThrowPoint.position, dumbbellThrowPoint.rotation, dumbbellThrowPoint);
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
        if (charge < 10)
        {
            charge++;
        }
    }
    public void Release_Dumbell()
    {
        if (!weight)
        {
            return;
        }
        weight.GetComponent<Dumbell>().Release();
    }
    public int getCharge()
    {
        return charge;
    }

    private void ActualThrow()
    {
        if (charge == 1 || charge == 4 || charge == 7)
        {
            //calls animator to perform throw
            animator.SetTrigger("Throw");

            //creates game object
            weight = (GameObject)Instantiate(dumbellPrefab, dumbbellThrowPoint.position, dumbbellThrowPoint.rotation, dumbbellThrowPoint);
            weight.GetComponent<Dumbell>().setCharge(charge);
        }
        else if (charge == 2 || charge == 5 || charge == 8)
        {
            //calls animator to perform disc
            animator.SetTrigger("Disc");

            //creates game object
        }
        else if (charge == 3 || charge == 6 || charge == 9)
        {
            //calls animator to perform roll
            animator.SetTrigger("Roll");

            //creates game object
            weight = (GameObject)Instantiate(barbellPrefab, barbellThrowPoint.position, barbellThrowPoint.rotation, barbellThrowPoint);
        }
        else if (charge == 10)
        {
            //calls animator to perform Big Boy

            //creates game object
        }
    }
}
