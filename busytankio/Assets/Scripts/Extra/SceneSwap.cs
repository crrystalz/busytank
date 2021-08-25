using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class SceneSwap: MonoBehaviour {  
    public void ServerScene() {  
        SceneManager.LoadScene("ServerScene");  
    }  
    public void StartMenu(){
        SceneManager.LoadScene("StartMenu");
    }
    public void LockerScene(){
        SceneManager.LoadScene("LockerScene");
    }
    public void SettingScene(){
        SceneManager.LoadScene("SettingScene");
    }
}   
