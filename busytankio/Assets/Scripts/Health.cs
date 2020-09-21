using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public TankMovement player;
    public int maxHP = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHP;
        healthBar.SetMaxHP(maxHP);
        player = GameObject.Find("Player").GetComponent<TankMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

        if (player.healthUp == true)
        {
            player.healthUp = false;
            if (currentHealth < 100)
            {
                if (currentHealth + 25 > 100)
                {
                    GetMaxHP();
                }
                else
                {
                    GetHP(25);
                }
                
            }

        }
    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHP(currentHealth);
    }
    void GetHP(int heal)
    {
        currentHealth += heal;

        healthBar.SetHP(currentHealth);
    }
    void GetMaxHP()
    {
        currentHealth += 100 - currentHealth;

        healthBar.SetHP(currentHealth);
    }
}
