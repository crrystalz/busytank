using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float turnspeed;
    public float gravitymultiplier;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // IMPORTANT!!! RIGHT = FORWARD  LEFT = BACKWARD !!!!!

        Move();
        Turn();
      
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.right * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-Vector3.right * speed);
        }
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.z = 0;
        rb.velocity = transform.TransformDirection(localVelocity);

    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnspeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnspeed);
        }
    }
}
