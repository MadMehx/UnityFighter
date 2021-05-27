using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbell : MonoBehaviour
{
    public float dumbellSpeed = 1f;
    public float modifier = 1f;
    public Rigidbody rb;

    public Animator Joe_Animator;

    private AnimatorClipInfo[] clipInfo;

    // Start is called before the first frame update
    void Start()
    {
        Joe_Animator = transform.parent.root.gameObject.transform.GetComponentInChildren<Animator>();
        //rb.velocity = new Vector3(0,0,1) * dumbellSpeed * modifier;
    }

    // Update is called once per frame
    void Update()
    {
        clipInfo = Joe_Animator.GetCurrentAnimatorClipInfo(0);

        if (clipInfo[0].clip.name == "Joe_Special_Windup")
        {
            //Debug.Log(WindupAnimationName);
            if (!Input.GetKey(KeyCode.V) || Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") > 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
