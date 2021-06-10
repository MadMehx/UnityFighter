using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbell : MonoBehaviour
{
    public ThrowSpecial throwSpecial;

    public float dumbellSpeed = 4f;
    public float modifier = 1f;
    public Rigidbody rb;

    public Animator Joe_Animator;

    private AnimatorClipInfo[] clipInfo;
    private int charge;
    private bool released = false;
    private bool hit = false;

    Vector3 throwPath;

    // Start is called before the first frame update
    void Start()
    {
        Joe_Animator = transform.parent.root.gameObject.transform.GetComponentInChildren<Animator>();//assigns the joe animator to a variable so we can reference which animation is happening
        //rb.velocity = new Vector3(0,0,1) * dumbellSpeed * modifier;
    }

    // Update is called once per frame
    void Update()
    {
        clipInfo = Joe_Animator.GetCurrentAnimatorClipInfo(0);//gets the name of the current animation

        if (clipInfo[0].clip.name == "Joe_Special_Windup") //checks that Joe is currently doing the curl animation, not the throw
        {
            if (!Input.GetKey(KeyCode.V) || Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") > 0)
            {
                Destroy(gameObject);
            }
        }

        if (released && !hit)
        {
            rb.velocity = new Vector3(0, 0, 1) * dumbellSpeed * modifier;
        }
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        if (!released)
        {
            return;
        }
        rb.velocity = new Vector3(0, -1, 0) * dumbellSpeed * modifier;
        hit = true;
    }

    public void Release()
    {
        this.transform.parent = null;
        this.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        released = true;
    }
}
