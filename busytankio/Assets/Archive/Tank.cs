using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Tank : MonoBehaviour
{
    public static GameObject MainPlayer;
    
    public static bool isPlayer(GameObject go)
    {
       return  go == MainPlayer;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
