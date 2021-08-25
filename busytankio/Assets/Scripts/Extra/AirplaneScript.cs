using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneScript : MonoBehaviour
{
    // Player Movement Variables/....
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;

    void Start()
    {

    }
    void Update()
    {
        
        transform.Translate(userDirection * movespeed * Time.deltaTime);
    }
}
