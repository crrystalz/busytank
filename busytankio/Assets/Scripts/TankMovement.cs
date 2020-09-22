using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public bool shildUp = false;
    public bool ammoUp = false;
    public bool healthUp = false;
    // public string tankCategory = "Scout Tank";
    public enum TankCategory {HeavyTank, ScoutTank, MortarTank, SniperTank};
    public TankCategory tankType;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
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