using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float turnspeed;
    public float gravitymultiplier;
    public int numPlayer;
    private Rigidbody rb;
    private PhotonView PV;
    public Camera myCam;
    public AudioListener myAL;

    

    public bool shildUp = false;
    public bool ammoUp = false;
    public bool healthUp = false;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // IMPORTANT!!! RIGHT = FORWARD  LEFT = BACKWARD !!!!!
        if (PV.IsMine)
        {
            Move();
            Turn();
        }
        else
        {
            Destroy(myCam);
            Destroy(myAL);
        }
        
      
    }

    void Move()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            //rb.AddRelativeForce(Vector3.forward * speed);
            rb.velocity = transform.forward * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //rb.AddRelativeForce(Vector3.back * speed);
            rb.velocity = transform.forward * -speed;
        }
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.z = 0;
        //rb.velocity = transform.TransformDirection(localVelocity);

    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddTorque(Vector3.up * turnspeed);
            transform.Rotate(Vector3.up, turnspeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //rb.AddTorque(-Vector3.up * turnspeed);
            transform.Rotate(Vector3.down, turnspeed * Time.deltaTime);
        }
    }
}
