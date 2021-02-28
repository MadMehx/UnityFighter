using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speed = 6f;
    private float verticalVelocity;
    public float fallSpeed = 4;
    public float jumpPower = 4;

    static float right = 0;
    static float left = 180;
    public static bool isAble = true;

    Vector3 direction;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -1;

            if (Input.GetKeyDown(KeyCode.UpArrow))
                verticalVelocity = jumpPower;
        }
        else
        {
            verticalVelocity -= fallSpeed * Time.deltaTime;
        }
        direction.y = verticalVelocity;

        //assigns direction based on player position
        float playerDirection = right;
        if (this.transform.eulerAngles.y == 180 || this.transform.eulerAngles.y == -180)
        {
            playerDirection = left;
        }

        //when the player presses arrow keys or WASD, the character will move along the z or y axis

        float horizontal = Input.GetAxisRaw("Horizontal");

        //depreciated
        //Vector3 direction = new Vector3(0f, vertical, horizontal).normalized;
        //new directional vector created to restrict vertical movement
        direction.z = horizontal;

        //triggers the walk animation
        if (horizontal != 0 && isAble)
        {
            WalkingAnimation(true);
        }

        //Turns player model towards a new direction if necessary
        if (horizontal < 0f && playerDirection == right)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            FlipAnimation();
        }
        else if (horizontal > 0f && playerDirection == left)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            FlipAnimation();
        }

        //moves the player along the direction vector
        if (direction.magnitude >= 0.1f && isAble)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        //triggers the walk animation
        if (horizontal == 0)
        {
            WalkingAnimation(false);
        }
    }

    void WalkingAnimation(bool value)
    {
        animator.SetBool("Move", value);
    }

    void FlipAnimation()
    {
        animator.SetTrigger("Flip");
    }

    public void SetAble(bool value)
    {
        Debug.Log("Hi");
        isAble = value;
    }

}
