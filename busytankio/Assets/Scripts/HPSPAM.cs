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

    private Vector3 pos = Vector3.zero;

    private float x1 = 0;
    private float y1 = 0;
    private float z1 = 0;

    
    public ShieldBar sp;
    public HealthBar hp;
    public Ammo am;

    public bool shildUp = false;
    public bool ammoUp = false;
    public bool healthUp = false;

    public PhotonView PV;

    public FloatyText prefab_floatyText;
    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            sp = FindObjectOfType<ShieldBar>();
            hp = FindObjectOfType<HealthBar>();
        }

        //int playerHP1 = playerHP;
        currentHP = playerHP;
        //int playerSP1 = playerSP;
        currentSP = playerSP;
        sp?.SetMaxHP(playerSP);
        hp?.SetMaxHP(playerHP);
    }

    // Update is called once per frame
    void Update()
    {

        x1 = transform.position.x;
        y1 = transform.position.y;
        z1 = transform.position.z;

        pos = new Vector3(x1, y1, z1);
        if (PV.IsMine)
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
        

    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (PV.IsMine)
        {
            if (other.gameObject.CompareTag("shild"))
            {
                PhotonNetwork.Destroy(other.gameObject);
                Debug.Log("Shield Collected");
                shildUp = true;
                FloatyText.Make(prefab_floatyText, "+Shield", other.transform.position);
            }

            if (other.gameObject.CompareTag("health"))
            {
                PhotonNetwork.Destroy(other.gameObject);
                Debug.Log("Meds Collected");
                healthUp = true;
                FloatyText.Make(prefab_floatyText, "+Health", other.transform.position);
            }

            if (other.gameObject.CompareTag("ammo"))
            {
                PhotonNetwork.Destroy(other.gameObject);
                Debug.Log("Ammo Collected");
                ammoUp = true;
                FloatyText.Make(prefab_floatyText, "+Ammo", other.transform.position);
            }
        }
        
    }

    void GetSP(int heal)
    {
        if (PV.IsMine)
        {
            playerSP += heal;
            currentSP += heal;
            

            sp.SetHP(currentSP);
        }

    }
    void GetMaxSP()
    {
        if (PV.IsMine)
        {
            playerSP += 100 - currentSP;
            currentSP += 100 - currentSP;

            hp.SetHP(currentSP);
        }
        
    }

    void GetHP(int heal)
    {
        if (PV.IsMine)
        {
            playerHP += heal;
            currentHP += heal;

            hp.SetHP(currentHP);
        }
            
    }
    void GetMaxHP()
    {
        if (PV.IsMine)
        {
            playerHP += 100 - currentSP;
            currentHP += 100 - currentHP;

            hp.SetHP(currentHP);
        }
            
    }

    public void TakeDamageHP(int damage)
    {

        if (PV.IsMine)
        {
            currentHP -= damage;

            hp.SetHP(currentHP);
            if (currentHP == 0)
            {
                PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Death Marker Variant"), pos, Quaternion.identity);
                PhotonNetwork.Destroy(gameObject);
                PhotonNetwork.Instantiate(Path.Combine("Prefabs", "CamCam"), Vector3.zero, Quaternion.identity);
            }
        }
       
       
        

        
        
    }
    public void TakeDamageSP(int damage)
    {
        if (PV.IsMine)
        {
            currentSP -= damage;

            sp.SetHP(currentSP); 

        }
        
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

