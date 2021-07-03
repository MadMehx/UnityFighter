using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbell : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity);
    }
}
