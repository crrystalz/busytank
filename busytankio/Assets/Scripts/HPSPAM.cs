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

    public GameObject spobj;
    public GameObject hpobj;
    public GameObject amobj;
    public HealthBar sp;
    public HealthBar hp;
    public Ammo am;

    public bool shildUp = false;
    public bool ammoUp = false;
    public bool healthUp = false;

    public PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            spobj = GameObject.FindGameObjectWithTag("healthbar");
            hpobj = GameObject.FindGameObjectWithTag("shieldbar");
            amobj = GameObject.FindGameObjectWithTag("ammobar");
           
        }
        
        currentHP = playerHP;
        currentSP = playerSP;
        sp.SetMaxHP(playerSP);
        hp.SetMaxHP(playerHP);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (shildUp == true)
        {
            shildUp = false;
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

        if (healthUp == true)
        {
            healthUp = false;
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

        if (ammoUp == true)
        {
            ammoUp = false;
            if (am.AmmoV < am.AmmoStart)
            {
                if (am.AmmoV + 25 > am.AmmoStart)
                {
                    GetMaxAMMO();
                }
                else
                {
                    GetAMMO(25);
                }

            }

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shild"))
        {
            PhotonNetwork.Destroy(other.gameObject);
            Debug.Log("Shield Collected");
            shildUp = true;
        }

        if (other.gameObject.CompareTag("health"))
        {
            PhotonNetwork.Destroy(other.gameObject);
            Debug.Log("Meds Collected");
            healthUp = true;
        }

        if (other.gameObject.CompareTag("ammo"))
        {
            PhotonNetwork.Destroy(other.gameObject);
            Debug.Log("Ammo Collected");
            ammoUp = true;
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
    void GetAMMO(int bullets)
    {
        am.AmmoV += bullets;

    }
    void GetMaxAMMO()
    {
        am.AmmoV += am.AmmoStart - am.AmmoV;

    }
}

