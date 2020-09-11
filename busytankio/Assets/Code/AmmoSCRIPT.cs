using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoSCRIPT : MonoBehaviour
{
    public PlayerMovementScript player;
    public int AmmoStart = 100;
    public int Ammo = 100;
    public Text ammotext;

    void Start()
    {
        player = GameObject.Find("Player 1").GetComponent<PlayerMovementScript>();
    }
    void Update()
    {
        ammotext.text = Ammo + " / " + AmmoStart;

        if (Input.GetKeyDown(KeyCode.D))
        {
            Ammo--;
        }

        if (player.ammoUp == true)
        {
            player.ammoUp = false;
            if (Ammo < AmmoStart)
            {
                if(Ammo + 25 > AmmoStart)
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
        Ammo += bullets;

    }
    void GetMaxAMMO()
    {
        Ammo += AmmoStart - Ammo;

    }
}
