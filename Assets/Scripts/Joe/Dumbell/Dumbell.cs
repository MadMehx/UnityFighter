using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumbell : MonoBehaviour
{
    public float dumbellSpeed = 1f;
    public float modifier = 1f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector3(0,0,1) * dumbellSpeed * modifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.V))
        {
            Destroy(gameObject);
        }
    }
}
