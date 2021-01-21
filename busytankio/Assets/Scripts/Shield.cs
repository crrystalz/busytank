using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Movement player;
    public int maxHP1 = 100;
    public int currentHealth1;
    public int damage;
    private PhotonView PV;
    public HealthBar healthBar1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth1 = maxHP1;
        healthBar1.SetMaxHP(maxHP1);
        healthBar1 = GameObject.Find("SheildBar").GetComponent<HealthBar>();
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            player = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
            healthBar1 = GameObject.Find("SheildBar").GetComponent<HealthBar>();
        }
        else
        {
            player = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
            healthBar1 = GameObject.Find("SheildBar").GetComponent<HealthBar>();
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

    public void TakeDamage1(int damage)
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
