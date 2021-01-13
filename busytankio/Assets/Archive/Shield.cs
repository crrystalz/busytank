using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public ThirdPersonMovement player;
    public int maxHP1 = 100;
    public int currentHealth1;

    public HealthBar shieldBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth1 = maxHP1;
        shieldBar.SetMaxHP(maxHP1);
        player = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeDamage1(1);
        }

        if (player.shildUp == true)
        {
            player.shildUp = false;
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

        shieldBar.SetHP(currentHealth1);
    }

    void GetSP(int heal)
    {
        currentHealth1 += heal;

        shieldBar.SetHP(currentHealth1);
    }
    void GetMaxSP()
    {
        currentHealth1 += 100 - currentHealth1;

        shieldBar.SetHP(currentHealth1);
    }
}
