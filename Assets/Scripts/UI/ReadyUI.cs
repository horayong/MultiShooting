using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ReadyUI : MonoBehaviourPun
{
    public static ReadyUI Instance { set; get; }

    [SerializeField] private Button readyButton;
    [SerializeField] private List<Image> playerPortrait;
    [SerializeField] private List<Sprite> characterSprite;
    [SerializeField] private List<Character> characterScript;

    private bool isReady = false;
    private int readyPlayerCount = 0;
    public int myCharacterIdx = 0;

    void Awake()
    {
        Instance = this;
    }

    public void OnClickCharacter(int idx)
    {
        if (!isReady)
        {
            Hashtable hash = new Hashtable();
            hash["selectedCharacter"] = idx;
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    public void OnClickReadyButton()
    {
        if (isReady) return;

        readyButton.interactable = false;
        isReady = true;

        NetworkManager.Instance.AddReadyPlayer();
        
    }
    public void UpdatePortraitUI(Player player, int idx)
    {
        if (player.ActorNumber == PhotonNetwork.LocalPlayer.ActorNumber)
        {
            myCharacterIdx = idx;
        }

        int playerIndex = player.ActorNumber - 1;
        playerPortrait[playerIndex].sprite = characterSprite[idx];
        Debug.Log($"{playerIndex} player select {idx}");
    }
}
