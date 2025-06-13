using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager networkManager;
    void Awake()
    {
        networkManager = this;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 4}, null);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }
    
}
