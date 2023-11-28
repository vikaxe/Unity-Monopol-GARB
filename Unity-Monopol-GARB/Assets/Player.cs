using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerIndex { get; private set; }
    public string playerName;
    public bool isMoving;

    public void InitializePlayer(int playerIndex, string name)
    {
        PlayerIndex = playerIndex;
        playerName = name;
        isMoving = false;
        // Eventuell annan initialisering för spelaren
    }
}
