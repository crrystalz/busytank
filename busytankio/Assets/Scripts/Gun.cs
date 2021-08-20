using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public HPSPAM hporsp;
    public GameObject player;
    public VisualEffect viseff;
    public GameObject impactEffect;
    public int numPlayer;

    private PhotonView PV;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Tank.isPlayer(gameObject))
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (hporsp.playerAM > 0)
            {
                //ViewID for PV
                if (PV.IsOwnerActive)
                {
                    PV.RPC("RPC_Shoot", RpcTarget.All);
                }
                else
                {
                    RPC_Shoot();
                }

            }
            else
            {
                Debug.Log("No more bullets! Go find some!");
            }
        }
        

    }
    [PunRPC]
    public void RPC_Shoot()
    {
        viseff.Play();
        hporsp.am.AmmoV -= 1;
        hporsp.playerAM -= 1;
        
        
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            HPSPAM target = hit.transform.GetComponent<HPSPAM>();
            HPSPAM enemy = hit.transform.gameObject.GetComponent<HPSPAM>();
            
            if (hit.transform.tag == "Player")
            {
                DealDamage(enemy);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2);
        }
    }

    void DealDamage(HPSPAM enemy)
    {
        if (enemy.playerSP > 0)
        {
            enemy.TakeDamageSP(hporsp.playerDamage);
            enemy.playerSP -= hporsp.playerDamage;
        }
        else if (enemy.playerSP <= 0)
        {
            enemy.TakeDamageHP(hporsp.playerDamage);
            enemy.playerHP -= enemy.playerDamage;
        }
    }
}
