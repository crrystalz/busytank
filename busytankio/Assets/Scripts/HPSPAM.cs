using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using System.IO;
using UnityEngine;

public class HPSPAM : MonoBehaviour
{

    public int playerHP;
    public int playerSP;
    public int playerAM;
    public int playerDamage;
    private int currentHP;
    private int currentSP;

    public HealthBar sp;
    public HealthBar hp;

    public Movement healthBar;
    public Movement shieldBar;

    public PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            List < HealthBar > bars = new List<HealthBar>(FindObjectsOfType<HealthBar>());
            sp = bars.Find((bar) =>
            {
                return bar.name.ToLower().Contains("sheild");
            });
            hp = bars.Find((bar) =>
            {
                return bar.name.ToLower().Contains("health");
            });
        }
        
        currentHP = playerHP;
        currentSP = playerSP;
        sp.SetMaxHP(playerSP);
        hp.SetMaxHP(playerHP);
    }

    // Update is called once per frame
    void Update()
    {
        shieldBar = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
        healthBar = GameObject.Find("ScoutTankPrefab").GetComponent<Movement>();
        if (shieldBar.shildUp == true)
        {
            shieldBar.shildUp = false;
            if (currentSP < 100)
            {
                if (currentSP + 25 > 100)
                {
                    GetMaxSP();
                }
                else
                {
                    GetSP(25);
                }

            }

        }

        if (healthBar.healthUp == true)
        {
            healthBar.healthUp = false;
            if (currentHP < 100)
            {
                if (currentHP + 25 > 100)
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shild"))
        {
            Destroy(other.gameObject);
            Debug.Log("Shield Collected");
            healthBar.shildUp = true;
        }

        if (other.gameObject.CompareTag("health"))
        {
            Destroy(other.gameObject);
            Debug.Log("Meds Collected");
            healthBar.healthUp = true;
        }

        if (other.gameObject.CompareTag("ammo"))
        {
            Destroy(other.gameObject);
            Debug.Log("Ammo Collected");
            healthBar.ammoUp = true;
        }
    }

    void GetSP(int heal)
    {
        currentSP += heal;

        sp.SetHP(currentSP);
    }
    void GetMaxSP()
    {
        currentSP += 100 - currentSP;

        hp.SetHP(currentSP);
    }

    void GetHP(int heal)
    {
        currentHP += heal;

        hp.SetHP(currentHP);
    }
    void GetMaxHP()
    {
        currentHP += 100 - currentHP;

        hp.SetHP(currentHP);
    }

    public void TakeDamageHP(int damage)
    {
        currentHP -= damage;

        hp.SetHP(currentHP);
        if (PV.IsMine)
        {
            if (currentHP == 0)
            {
                PhotonNetwork.Destroy(gameObject);
                PhotonNetwork.Instantiate(Path.Combine("Prefabs", "CamCam"), Vector3.zero, Quaternion.identity);
            }
        }
        
    }

    public void TakeDamageSP(int damage)
    {
        currentSP -= damage;

        sp.SetHP(currentSP); 
    }
}

