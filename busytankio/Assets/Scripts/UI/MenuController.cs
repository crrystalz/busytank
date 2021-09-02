using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    private bool tufa = false;
    public float timer = 0.0f;
    private void Update()
    {
        if(timer != 0.0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if(timer <= 0.0f)
            {
                if (tufa)
                {
                    menu.SetActive(false);
                    tufa = false;
                    timer = 2.0f;
                }

                else
                {
                    menu.SetActive(true);
                    tufa = true;
                    timer = 2.0f;
                }
            }
        }
    }
    public void DelayCancel()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("StartMenu");
        
    }
}
