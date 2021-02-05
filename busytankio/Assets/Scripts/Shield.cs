using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Movement player;
    public int maxShield = 8;
    public int currentShield;
    public int damage;
    private PhotonView PV;
    public HealthBar shieldBar;

    // Start is called before the first frame update
    void Start()
    {
        TankAttributes tankAttributes = GetComponent<TankAttributes>();
        maxShield = tankAttributes.Shield;
        currentShield = maxShield;

        shieldBar.SetMaxHP(maxShield);
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            player = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
            shieldBar = GameObject.Find("ShieldBar").GetComponent<HealthBar>();
        }
        else
        {
            player = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
            shieldBar = GameObject.Find("ShieldBar").GetComponent<HealthBar>();
        }

        if (player.shildUp == true)
        {
            player.shildUp = false;
            if (currentShield < 100)
            {
                if (currentShield + 25 > 100)
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

    public void TakeDamage(int damage)
    {
        currentShield -= damage;

        shieldBar.SetHP(currentShield);
    }

    void GetSP(int heal)
    {
        currentShield += heal;

        shieldBar.SetHP(currentShield);
    }

    void GetMaxSP()
    {
        currentShield += 100 - currentShield;

        shieldBar.SetHP(currentShield);
    }

    void SetMaxSP(int max) {
        maxShield = max;
    }
}
