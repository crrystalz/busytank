using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    void ConstantShoot()
    {
        Gun g = GetComponent<Gun>();
        g.RPC_Shoot();
        Timer.getTimer().addTask(3000, ConstantShoot);
    }

    // Start is called before the first frame update
    void Start()
    {
        ConstantShoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
