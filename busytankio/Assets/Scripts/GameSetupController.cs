using Photon.Pun;
using System.IO;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Loading Player.");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "ScoutTankPrefab"), Vector3.up*10, Quaternion.identity);
    }
}
