using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance { set; get; }
    private int readyPlayerCount = 0;
    void Awake()
    {
        Instance = this;
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 4 }, null);
    }
    public override void OnJoinedRoom()
    {
        //GameObject temp = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        //GameManager.Instance.myCharacter = temp;
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("selectedCharacter"))
        {
            int selected = (int)changedProps["selectedCharacter"];
            ReadyUI.Instance.UpdatePortraitUI(targetPlayer, selected);
        }
    }
    public void AddReadyPlayer()
    {
        photonView.RPC("AddReadyPlayerPun", RpcTarget.MasterClient);
    }
    [PunRPC]
    public void AddReadyPlayerPun()
    {
        readyPlayerCount++;
        // 마스터 클라이언트에서만 InitGame 호출 판단
        if (PhotonNetwork.IsMasterClient && readyPlayerCount >= GameManager.Instance.maxPlayers)
        {
            photonView.RPC("StartGamePun", RpcTarget.All);
        }
    }

    [PunRPC]
    public void StartGamePun()
    {
        GameManager.Instance.InitGame();
    }
}
