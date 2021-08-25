using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartWaitingRoom : MonoBehaviourPunCallbacks
{

    private PhotonView thePhotonView;

    [SerializeField]
    private int multiplayerSceneIndex;
    [SerializeField]
    private int menuSceneIndex;

    private int playerCount;
    private int roomSize;
    [SerializeField]
    private int minPlayersToStart;

    [SerializeField]
    private Text playerCountDisplay;
    [SerializeField]
    private Text countdownDisplay;

    private bool readyToCountdown;
    private bool readyToStart;
    private bool startingGame;

    private float timerToPlay;
    private float notFullGameTimer;
    private float fullGameTimer;

    [SerializeField]
    private float maxWaitTime;
    [SerializeField]
    private float maxFullGameTime;

    // Start is called before the first frame update
    private void Start()
    {
        thePhotonView = GetComponent<PhotonView>();
        fullGameTimer = maxFullGameTime;
        notFullGameTimer = maxWaitTime;
        timerToPlay = maxWaitTime;

        PlayerCountUpdate();
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        playerCountDisplay.text = playerCount + "/" + roomSize + " have joined!";

        if (playerCount == roomSize)
        {
            readyToStart = true;
        }
        else if (playerCount >= minPlayersToStart)
        {
            readyToCountdown = true;
        }
        else
        {
            readyToCountdown = false;
            readyToStart = false;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerCountUpdate();
        if (PhotonNetwork.IsMasterClient)
        {
            thePhotonView.RPC("RPC_SendTimer", RpcTarget.Others, timerToPlay);
        }
    }

    [PunRPC]
    private void RPC_SendTimer(float timein)
    {
        timerToPlay = timein;
        notFullGameTimer = timein;
        if(timein < fullGameTimer)
        {
            fullGameTimer = timein;
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerCountUpdate();
    }

    private void Update()
    {
        WaitingForMorePlayers();
    }
    void WaitingForMorePlayers()
    {
        if(playerCount <= 1)
        {
            ResetTimer();
        }

        if (readyToStart)
        {
            fullGameTimer -= Time.deltaTime;
            timerToPlay = fullGameTimer;
        }
        else if (readyToCountdown)
        {
            notFullGameTimer -= Time.deltaTime;
            timerToPlay = notFullGameTimer;
        }

        string tempTimer = string.Format("{0:00}", timerToPlay);
        countdownDisplay.text = tempTimer;
        if(timerToPlay <= 0f)
        {
            if (startingGame)
                return;
            StartGame();
        }
    }

    void ResetTimer()
    {
        timerToPlay = maxWaitTime;
        notFullGameTimer = maxWaitTime;
        fullGameTimer = maxFullGameTime;
    }

    public void StartGame()
    {
        startingGame = true;
        if (!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }

    public void DelayCancel()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(menuSceneIndex);
    }

}
