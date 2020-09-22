using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    // public float speed = 6f;
    public enum TankCategory {HeavyTank, ScoutTank, MortarTank, SniperTank};
    public TankCategory tankType;
    private int health = 100;
    private int attack = 100;
    private int speed = 100;
    private int zoom = 100;
    private int view = 100;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Health and Stuff
    public bool shildUp = false;
    public bool ammoUp = false;
    public bool healthUp = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        switch(tankType)
        {
            case TankCategory.HeavyTank:
                Debug.Log("Setting HeavyTank Properties");
                health = 120;
                speed = 70;
            break;

            case TankCategory.ScoutTank:
                Debug.Log("Setting ScoutTank Properties");
                attack = 90;
                speed = 110;
                zoom = 104;
            break;

            case TankCategory.MortarTank:
                Debug.Log("Setting MortarTank Properties");
                attack = 130;
                speed = 60;
                view = 108;
            break;
            
            case TankCategory.SniperTank:
                Debug.Log("Setting SniperTank Properties");
                health = 70;
                attack = 125;
                zoom = 130;
            break;
        }
    }


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed / 20 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shild"))
        {
            Destroy(other.gameObject);
            Debug.Log("Shield Collected");
            shildUp = true;
        }

        if (other.gameObject.CompareTag("health"))
        {
            Destroy(other.gameObject);
            Debug.Log("Meds Collected");
            healthUp = true;
        }

        if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            Debug.Log("Ammo Collected");
            ammoUp = true;
        }
    }
}

