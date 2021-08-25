using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocker : MonoBehaviour
{
    public RotateLocker r1;
    public RotateLocker l1;
    public Transform model;
    public Transform model2;
    public int speed;
    public int tankSelection = 1;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Model")){
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        
    }

    public void NextTank(){
        if(r1.tankSelection != 2 || l1.tankSelection != 2 ){
            Vector3 position = transform.position;
            float X = model.transform.position.x - 1170.0f;
            model.transform.position = new Vector3(X, 338.5f, 479);
            float X2 = model2.transform.position.x - 1170.0f;
            model2.transform.position = new Vector3(X2, 338.5f, 479);
            r1.tankSelection += 1;
            l1.tankSelection += 1;

        }
        
    }
    public void PrevTank(){
        if(r1.tankSelection != 1 || l1.tankSelection != 1){
            Vector3 position = transform.position;
            float X = model.transform.position.x + 1170.0f;
            model.transform.position = new Vector3(X, 338.5f, 479);
            float X2 = model2.transform.position.x + 1170.0f;
            model2.transform.position = new Vector3(X2, 338.5f, 479);
            r1.tankSelection -= 1;
            l1.tankSelection -= 1;

        }
        

    }
}
