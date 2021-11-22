using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projController : MonoBehaviour
{
    Rigidbody rb;

    public Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
