using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using System.IO;
using UnityEngine;

public class CameraScriptMultiplayer : MonoBehaviour
{
    public float speed;
    public float turnspeed;
    private Rigidbody rb;
    private PhotonView PV;
    public Camera myCam;
    public AudioListener myAL;
    int stall = 0;
    // Start is called before the first frame update
    void Start()
    {
        speed = 50;
        turnspeed = 50;
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
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
