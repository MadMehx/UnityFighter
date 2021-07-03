using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbell : MonoBehaviour
{
    public ThrowSpecial throwSpecial;

    [SerializeField]private float dumbellInitialZSpeed = 1f;
    [SerializeField]private float dumbellInitialYSpeed = 1f;
    [SerializeField]private float fallSpeed = 4;
    public Rigidbody rb;

    public Animator Joe_Animator;
    public GameObject Joe;

    private AnimatorClipInfo[] clipInfo;
    private int charge;
    private bool released = false;
    private int[] DamageValues = new int[10] {6, 3, 10, 12, 9, 20, 18, 15, 30, 33};//stores damage values for the number of pumps done

    // Start is called before the first frame update
    void Start()
    {
        Joe_Animator = transform.parent.root.gameObject.transform.GetComponentInChildren<Animator>();
        //assigns the joe animator to a variable so we can reference which animation is happening
        Joe = transform.parent.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        clipInfo = Joe_Animator.GetCurrentAnimatorClipInfo(0);//gets the name of the current animation

        if (clipInfo[0].clip.name == "Joe_Special_Windup") //checks that Joe is currently doing the curl animation, not the throw
        {
            if (!Input.GetKey(KeyCode.V) || Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") > 0)
            {
                if (!released)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (released)
        {

                rb.velocity += new Vector3(0, (-fallSpeed * Time.deltaTime), 0);
        }
    }

    public void setCharge(int chargeFromThrowSpecial = 1)
    {
        charge = chargeFromThrowSpecial;
    }
     
    private void OnTriggerEnter(Collider hitInfo)// is called when the dumbell collides with something
    {
        if (!released || charge < 1 || charge > 10)
        {
            return;
        }
        try
        {
            hitInfo.GetComponent<HealthScript>().TakeDamage(DamageValues[charge-1]);

            Debug.Log("We hit " + hitInfo.name + "with " + DamageValues[charge-1] + " power. They have " +
                    hitInfo.GetComponent<HealthScript>().getHealth() + " health left");
        }
        catch 
        {
            Debug.Log("Hit a wall or something");
        }

        if(hitInfo.name != "Joe_Player")
            Destroy(gameObject);
    }

    public void Release()// called when the dumbell is ready to leave Joe's hand.
    {
        this.transform.parent = null;
        this.transform.position = new Vector3(0, transform.position.y, transform.position.z);
        released = true;

        if (getDirection() == 1)//only if Joe is facing right
        {
            rb.velocity = new Vector3(0, dumbellInitialYSpeed, dumbellInitialZSpeed);//launches dumbbell    
        }
        else if (getDirection() == -1)
        {
            rb.velocity = new Vector3(0, dumbellInitialYSpeed, -dumbellInitialZSpeed);//launches dumbbell 
        }
        else
            return;
    }

    public int getDirection()
    {
        return Joe.GetComponentInChildren<CharacterMovement>().ReturnDirection();
    }
}
