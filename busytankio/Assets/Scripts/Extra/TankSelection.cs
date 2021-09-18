using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TankSelection : MonoBehaviour
{
    
    public int tankNumber = 1;
    public int logoNumber = 1;
    public static TankSelection instance;
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
    
}
