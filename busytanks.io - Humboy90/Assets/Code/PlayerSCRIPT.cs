using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSCRIPT : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHP;
        healthBar.SetMaxHP(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHP(currentHealth);
    }
}
