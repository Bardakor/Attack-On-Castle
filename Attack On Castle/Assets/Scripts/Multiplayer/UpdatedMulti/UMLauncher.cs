using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;

public class UMLauncher : MonoBehaviourPunCallbacks
{
    public static UMLauncher Instance;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject playerListItemPrefab;

    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject levelselector;
    //removed from list component
    [SerializeField] GameObject leaveRoomButton;
    public int LevelNumber;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {  
        Debug.Log("Connection to Master...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        //sync scene
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        UMMenuManager.Instance.OpenMenu("Title");
        Debug.Log("Joined lobby");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        UMMenuManager.Instance.OpenMenu("Loading");
    }
    public void ChangeLevelNumber (string lvl) {
        LevelNumber = int.Parse(lvl);
        Debug.Log("Level number is now " + LevelNumber);
    }

    public override void OnJoinedRoom()
    {
        UMMenuManager.Instance.OpenMenu("Room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<UMPlayerListItem>().SetUp(players[i]);
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        levelselector.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        levelselector.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room creation failed : " + message;
        UMMenuManager.Instance.OpenMenu("Error");
    }

    public void StartGame()
    {
        if (1 <= LevelNumber && LevelNumber <= 11)
        {
            PhotonNetwork.LoadLevel(LevelNumber);
        }
        else
        {
            Debug.LogError("Level number is out of range\nDefault 1");
            PhotonNetwork.LoadLevel(1);
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        UMMenuManager.Instance.OpenMenu("Loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        UMMenuManager.Instance.OpenMenu("Loading");
    }

    public override void OnLeftRoom()
    {
        UMMenuManager.Instance.OpenMenu("Title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform child in roomListContent)
        {
            Destroy(child.gameObject);
        }
        //loop trough the list
        for (int i = 0; i < roomList.Count; i++)
        {
            if(roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<UMRoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<UMPlayerListItem>().SetUp(newPlayer);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
