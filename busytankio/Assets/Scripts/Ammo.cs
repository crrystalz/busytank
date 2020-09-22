using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ammo: MonoBehaviour
{
    public TankMovement player;
    public int AmmoStart = 100;
    public int AmmoV = 100;
    public Text ammotext;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<TankMovement>();
    }
    void Update()
    {
        ammotext.text = AmmoV + " / " + AmmoStart;

        if (Input.GetKeyDown(KeyCode.D))
        {
            AmmoV--;
        }

        if (player.ammoUp == true)
        {
            player.ammoUp = false;
            if (AmmoV < AmmoStart)
            {
                if(AmmoV + 25 > AmmoStart)
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

    void GetAMMO(int bullets)
    {
        AmmoV += bullets;

    }
    void GetMaxAMMO()
    {
        AmmoV += AmmoStart - AmmoV;

    }
}
