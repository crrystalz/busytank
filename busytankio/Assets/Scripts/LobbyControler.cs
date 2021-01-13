using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class LobbyControler : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject delayStartButton;
    [SerializeField]
    private GameObject delayCancelButton;
    [SerializeField]
    private int roomsize;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        delayStartButton.SetActive(true);
        
    }

    public void DelayStart()
    {
        delayStartButton.SetActive(false);
        delayCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Finding a match...");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
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

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... trying again.");
        CreateRoom();
    }

    public void DelayCancel()
    {
        delayCancelButton.SetActive(false);
        delayStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
