using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Movement player;
    public int maxHP = 100;
    public int currentHealth;
    public int damage;
    public HealthBar healthBar;
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHP;
        healthBar.SetMaxHP(maxHP);
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PV.IsMine)
        {
            player = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
            healthBar = GameObject.Find("SheildBar").GetComponent<HealthBar>();
        }
        else
        {
            player = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
            healthBar = GameObject.Find("SheildBar").GetComponent<HealthBar>();
        }
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

    public void TakeDamage (int damage)
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
