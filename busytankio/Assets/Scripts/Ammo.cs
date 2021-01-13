using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ammo: MonoBehaviour
{
    public Movement ammo;
    public int AmmoStart = 100;
    public HPSPAM AmmoV;
    public Text ammotext;

    void Start()
    {
        AmmoV = GameObject.Find("ScoutTankPrefab(Clone)").GetComponent<HPSPAM>();
        ammo = GameObject.Find("ScoutTankPrefab(Clone)").GetComponent<Movement>();
    }
    void Update()
    {
        ammotext.text = AmmoV.playerAM + " / " + AmmoStart;


        if (ammo.ammoUp == true)
        {
            
            if (AmmoV.playerAM < AmmoStart)
            {
                if(AmmoV.playerAM + 25 > AmmoStart)
                {
                    GetMaxAMMO();
                }
                else
                {
                    GetAMMO(25);
                }
                
            }
            ammo.ammoUp = false;

        }
    }

    void GetAMMO(int bullets)
    {
        AmmoV.playerAM += bullets;

    }
    void GetMaxAMMO()
    {
        AmmoV.playerAM += AmmoStart - AmmoV.playerAM;

    }
}
