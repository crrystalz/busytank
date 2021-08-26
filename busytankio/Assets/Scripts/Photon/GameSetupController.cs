using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    public RotateLocker rl;
    // Start is called before the first frame update
    void Start()
    {
        rl = GameObject.Find("TankSelector").GetComponent<RotateLocker>();
        if(rl.tankSelection == 1){
            CreateMortar();
        }
        if(rl.tankSelection == 2){
            CreateScout();
        }
        
    }

    private void CreateScout()
    {
        Debug.Log("Loading Player.");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "ScoutTankPrefab"), Vector3.up*10, Quaternion.identity);
    }
    private void CreateMortar()
    {
        Debug.Log("Loading Player.");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "MortarTankPref"), Vector3.up*10, Quaternion.identity);
    }
}
