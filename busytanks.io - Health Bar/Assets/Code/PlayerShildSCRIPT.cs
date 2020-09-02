using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShildSCRIPT : MonoBehaviour
{
    public int maxHP1 = 100;
    public int currentHealth1;
    public int o100 = 100;

    public HealthBar healthBar1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth1 = maxHP1;
        healthBar1.SetMaxHP(maxHP1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeDamage1(1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (currentHealth1 < o100)
            {
                GetHP(25);
            }
            
        }

    }

    void TakeDamage1(int damage)
    {
        currentHealth1 -= damage;

        healthBar1.SetHP(currentHealth1);
    }

    void GetHP(int heal)
    {
        currentHealth1 += heal;

        healthBar1.SetHP(currentHealth1);
    }
}
