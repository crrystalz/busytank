using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ammo : MonoBehaviour
{
    public enum TankCategory { HeavyTank, ScoutTank, MortarTank, SniperTank };
    public TankCategory tankType;
    
    public int AmmoStart = 100;
    public int AmmoV = 100;
    public Text ammotext;

    void Start()
    {
        

        switch (tankType)
        {
            case TankCategory.HeavyTank:
                break;

            case TankCategory.ScoutTank:
                break;

            case TankCategory.MortarTank:
                break;

            case TankCategory.SniperTank:
                break;
        }
    }
    void Update()
    {
        ammotext.text = AmmoV + " / " + AmmoStart;
    }

}
