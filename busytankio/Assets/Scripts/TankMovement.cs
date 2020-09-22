using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public CharacterController controller;

    // public float speed = 6f;
    public bool shildUp = false;
    public bool ammoUp = false;
    public bool healthUp = false;
    // public string tankCategory = "Scout Tank";
    public enum TankCategory {HeavyTank, ScoutTank, MortarTank, SniperTank};
    public TankCategory tankType;
    private int health = 100;
    private int attack = 100;
    private int speed = 100;
    private int zoom = 100;
    private int view = 100;

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
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed / 20 * Time.deltaTime);
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