﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladesScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 120f);
    }
}
