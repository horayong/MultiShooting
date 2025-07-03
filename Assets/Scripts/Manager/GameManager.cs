using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public int maxPlayers = 4;
    public GameObject myCharacter;
    void Awake()
    {
        Instance = this;   
    }
    public void InitGame()
    {
        int cIdx = ReadyUI.Instance.myCharacterIdx;
        switch (cIdx)
        {
            case 0:
                PhotonNetwork.Instantiate("Warrior", Vector3.zero, Quaternion.identity);
                break;
            case 1:
                PhotonNetwork.Instantiate("Archer", Vector3.zero, Quaternion.identity);
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
        Debug.Log("GameStart");
    }
    
}
