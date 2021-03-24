using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Throw : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.parent = null;
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.parent = Joe_Player.joe.hand.R;
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }
}
