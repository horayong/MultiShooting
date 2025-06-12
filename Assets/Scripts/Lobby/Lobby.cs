using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{
    [Header("---UI InputFields---")]
    public TMP_InputField createRoom;
    public TMP_InputField joinRoom;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }
    public override void OnJoinedLobby()
    {

    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {

    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        int roomName = Random.Range(0, 10000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName.ToString(), roomOptions, TypedLobby.Default, null);
    }
    public void OnClickCreateButton()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        //PhotonNetwork.CreateRoom(createRoom.text, roomOptions, typedLobby.Default, null);
    }
}
