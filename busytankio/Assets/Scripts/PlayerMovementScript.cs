using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public bool shildUp = false;
    public bool ammoUp = false;
    public bool healthUp = false;
    public bool isUp = false;
    public bool isDown = false;
    public bool isRight = false;
    public bool isLeft = false;

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode moveU;
    public KeyCode moveD;
    Rigidbody rb;
    public float horizVel = 0;
    public float vertVel = 0;
    public int laneNum = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(horizVel, 0, vertVel);
        if (Input.GetKeyDown(moveL))
        {
            horizVel = -2;
            StartCoroutine(stopSlide());

        }
        if (Input.GetKeyDown(moveR))
        {
            horizVel = 2;
            StartCoroutine(stopSlide());

        }
        if (Input.GetKeyDown(moveU))
        {
            vertVel = 2;
            StartCoroutine(stopSlead());
            

        }
        if (Input.GetKeyDown(moveD))
        {
            vertVel = -2;
            StartCoroutine(stopSlead());

        }
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
    }
    IEnumerator stopSlead()
    {
        yield return new WaitForSeconds(.5f);
        vertVel = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shild"))
        {
            Destroy(other.gameObject);
            Debug.Log("Shild Collected");
            shildUp = true;
        }

        if (other.gameObject.CompareTag("health"))
        {
            Destroy(other.gameObject);
            Debug.Log("Medkit Collected");
            healthUp = true;
        }

        if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            Debug.Log("Ammo Collected");
            ammoUp = true;
        }
    }

    private void turn180()
    {
        if (isUp == true)
        {

        }
    }
}
