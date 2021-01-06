using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private int roomsize;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Finding a match...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected!");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room open, createing a match.");
        CreateRoom();
    }

    void CreateRoom()
    {
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomsize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
