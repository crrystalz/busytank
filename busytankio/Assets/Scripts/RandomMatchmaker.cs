using UnityEngine;

public class RandomMatchmaker : Photon.PunBehaviour
{
    // Controls a player
    public static int playerNum = 0;
    // The player count
    private int numPlayerCounter = 0;
    private PhotonView myPhotonView;
    Vector3 postiton = new Vector3(0, 4.48f, 0);
    // Use this for initialization
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("JoinRandom");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        // when AutoJoinLobby is off, this method gets called when PUN finished the connection (instead of OnJoinedLobby())
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate("ScoutTankPrefab", postiton, Quaternion.identity, 0);
        numPlayerCounter++;
        myPhotonView = player.GetComponent<PhotonView>();
        //player.GetComponent<Movement>().numPlayer = numPlayerCounter;
        //player.GetComponent<Gun>().numPlayer = numPlayerCounter;
    }

    public void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

        if (PhotonNetwork.inRoom)
        {
            /*bool shoutMarco = GameLogic.playerWhoIsIt == PhotonNetwork.player.ID;

            if (shoutMarco && GUILayout.Button("Marco!"))
            {
                myPhotonView.RPC("Marco", PhotonTargets.All);
            }
            if (!shoutMarco && GUILayout.Button("Polo!"))
            {
                myPhotonView.RPC("Polo", PhotonTargets.All);
            }*/
        }
    }
    
    public void shootRaycast()
    {

    }

    public void severMove()
    {

    }
}
