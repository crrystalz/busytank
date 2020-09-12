using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public PlayerMovementScript player;
    public int maxHP1 = 100;
    public int currentHealth1;
    public int o100 = 100;

    public HealthBar healthBar1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth1 = maxHP1;
        healthBar1.SetMaxHP(maxHP1);
        player = GameObject.Find("Player").GetComponent<PlayerMovementScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeDamage1(1);
        }

        if (player.shieldUp == true)
        {
            player.shieldUp = false;
            if (currentHealth1 < 100)
            {
                if (currentHealth1 + 25 > 100)
                {
                    GetMaxSP();
                }
                else
                {
                    GetSP(25);
                }
                
            }
            
        }
        

    }

    void TakeDamage1(int damage)
    {
        currentHealth1 -= damage;

        healthBar1.SetHP(currentHealth1);
    }

    void GetSP(int heal)
    {
        currentHealth1 += heal;

        healthBar1.SetHP(currentHealth1);
    }
    void GetMaxSP()
    {
        currentHealth1 += 100 - currentHealth1;

        healthBar1.SetHP(currentHealth1);
    }
}
