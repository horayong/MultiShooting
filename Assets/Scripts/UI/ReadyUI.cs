using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUI : MonoBehaviour
{
    [SerializeField] private Button readyButton;
    private bool isReady = false;
    private int chIdx;

    public void OnClickCharacter(int idx)
    {
        if (!isReady)
        {
            chIdx = idx;
        }
        
    }
    public void OnClickReadyButton()
    {
        readyButton.interactable = false;
        isReady = true;
    }
}
