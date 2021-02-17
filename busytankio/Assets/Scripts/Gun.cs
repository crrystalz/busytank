using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public HPSPAM hporsp;
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
        if (PV.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hporsp.playerAM > 0)
                {
                    PV.RPC("RPC_Shoot", RpcTarget.All);
                }
                else
                {
                    Debug.Log("No more bullets! Go find some!");




                }
            }
        }

    }
    [PunRPC]
    void RPC_Shoot ()
    {
        particalsystem.Play();
        hporsp.playerAM -= 1;
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            HPSPAM target = hit.transform.GetComponent<HPSPAM>();
            if (hit.transform.tag == "Player")
            {
                if(hit.transform.gameObject.GetComponent<HPSPAM>().playerSP > 0)
                {
                    hit.transform.gameObject.GetComponent<HPSPAM>().TakeDamageSP(hporsp.playerDamage);
                }
                else
                {
                    hit.transform.gameObject.GetComponent<HPSPAM>().TakeDamageHP(hporsp.playerDamage);
                }
                
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2);
        }
    }
}
