using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateScout();
    }

    private void CreateScout()
    {
        Debug.Log("Loading Player.");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "ScoutTankPrefab"), Vector3.up*10, Quaternion.identity);
    }
    private void CreateMortar()
    {
        Debug.Log("Loading Player.");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "ScoutTank(2Part)"), Vector3.up*10, Quaternion.identity);
    }
}
