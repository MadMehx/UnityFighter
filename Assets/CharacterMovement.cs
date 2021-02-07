using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    static float right = 0;
    static float left = 180;

    // Update is called once per frame
    void Update()
    {

        float playerDirection = right;
        if (this.transform.eulerAngles.y == 180 || this.transform.eulerAngles.y == -180)
        {
            playerDirection = left;
        }

        //when the player presses arrow keys or WASD, the character will move along the z or y axis

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(0f, vertical, horizontal).normalized;


        if (horizontal < 0f && playerDirection == right)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }
        else if (horizontal > 0f && playerDirection == left)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //moves the player along the direction vector
        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }

    void WalkingAnimation()
    {
        
    }
}
