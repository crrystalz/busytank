using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Health health;
    public Shield shield;
    public GameObject player;
    public ParticleSystem particalsystem;
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
        
        if (Input.GetButton("Fire1"))
        {
            PV.RPC("RPC_Shoot", RpcTarget.All);
            //Fix later
            //if (hporsp.playerAM > 0)
            //{
            //PV.RPC("RPC_Shoot", RpcTarget.All);
            //}
            //else
            //{
             //   Debug.Log("No more bullets! Go find some!");


            
                    
            //}
        }

    }
    [PunRPC]
    void RPC_Shoot ()
    {
        particalsystem.Play();
        //Also Fix later
        //hporsp.playerAM -= 1;
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            HPSPAM target = hit.transform.GetComponent<HPSPAM>();
            if (hit.transform.tag == "Player")
            {
                if(shield.currentHealth1 > 0)
                {
                    shield.TakeDamage1(shield.damage);
                }
                else
                {
                    health.TakeDamage(health.damage);
                }
                
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2);
        }
    }
}
