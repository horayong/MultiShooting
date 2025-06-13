using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }
    public int maxPlayers = 4;
    void Awake()
    {
        Instance = this;   
    }

    
}
