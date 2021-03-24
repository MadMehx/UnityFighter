using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpecial : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject dumbellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int charge = 0;
        Debug.Log(charge);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(dumbellPrefab, throwPoint.position, throwPoint.rotation);
        }
    }
}
