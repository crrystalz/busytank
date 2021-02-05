using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TankType 
{
    Scout,
    Heavy,
    Sniper,
    Mortar
};

public class TankAttributes : MonoBehaviour
{
    public TankType tankType = new TankType();

    public int Health = 0;
    public int Shield = 0;
    public int Attack = 0;
    public int Speed = 0;
    public int Zoom = 0;
    public int View = 0;

    // Start is called before the first frame update
    void Start()
    {
        switch (tankType)
        {
        case TankType.Scout:
            Debug.Log("Scout");
            Health = 100;
            Shield = 100;
            Attack = 90;
            Speed = 110;
            Zoom = 104;
            View = 100;
            break;
        case TankType.Heavy:
            Debug.Log("Heavy");
            Health = 120;
            Shield = 100;
            Attack = 100;
            Speed = 70;
            Zoom = 100;
            View = 100;
            break;
        case TankType.Sniper:
            Debug.Log("Sniper");
            Health = 70;
            Shield = 100;
            Attack = 125;
            Speed = 100;
            Zoom = 130;
            View = 100;
            break;
        case TankType.Mortar:
            Debug.Log("Mortar");
            Health = 100;
            Shield = 100;
            Attack = 130;
            Speed = 60;
            Zoom = 100;
            View = 108;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
