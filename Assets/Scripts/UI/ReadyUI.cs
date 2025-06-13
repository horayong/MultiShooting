using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class ReadyUI : MonoBehaviour
{
    public static ReadyUI Instance { set; get; }
    [SerializeField] private Button readyButton;
    [SerializeField] List<Image> playerPortrait;
    [SerializeField] List<Sprite> characterSprite;
    private bool isReady = false;
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
        readyButton.interactable = false;
        isReady = true;
    }
    public void UpdatePortraitUI(Player player, int idx)
    {
        int playerIndex = player.ActorNumber - 1;
        playerPortrait[playerIndex].sprite = characterSprite[idx];
        Debug.Log($"{playerIndex} player select {idx}");
    }
}
