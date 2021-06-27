using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{

    //public Transform cam;
    // Start is called before the first frame update

    
    void LateUpdate()
    {
        //transform.LookAt(transform.position + cam.forward);
        Calculate(transform);
    }

    public static void Calculate(Transform target)
    {
        Camera cam= Camera.main;
        target.LookAt(target.position + cam.transform.forward);
    }
}
