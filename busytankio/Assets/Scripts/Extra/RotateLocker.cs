using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RotateLocker : MonoBehaviour
{
    public Transform model;
    public Transform model2;
    public int speed;
    public int tankSelection = 1;
    public static RotateLocker instance;
    public bool scener = true;
    void Awake(){

        

        if(this.CompareTag("Selector") == true){
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }  
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LockerScene")){
            if(this.CompareTag("Selector") == true){
                if(scener == true){
                    model = GameObject.Find("Busytankio_Mortar_Tank").GetComponent<Transform>();
                    model2 = GameObject.Find("Busytankio Scout Tank").GetComponent<Transform>();
                    scener = false;
                }
            }            
        }
        else{
            scener = true;
        }
        if (gameObject.CompareTag("Model")){
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        
    }

    public void NextTank(){
        if(tankSelection != 2){
            Vector3 position = transform.position;
            float X = model.transform.position.x - 1170.0f;
            model.transform.position = new Vector3(X, 338.5f, 479);
            float X2 = model2.transform.position.x - 1170.0f;
            model2.transform.position = new Vector3(X2, 338.5f, 479);
            tankSelection += 1;

        }
        
    }
    public void PrevTank(){
        if(tankSelection != 1){
            Vector3 position = transform.position;
            float X = model.transform.position.x + 1170.0f;
            model.transform.position = new Vector3(X, 338.5f, 479);
            float X2 = model2.transform.position.x + 1170.0f;
            model2.transform.position = new Vector3(X2, 338.5f, 479);
            tankSelection -= 1;

        }
        

    }
}
