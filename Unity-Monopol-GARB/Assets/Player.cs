using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerIndex { get; private set; }
    public string playerName;
    public bool isMoving;
    public double cash = 1000;

    public void InitializePlayer(int playerIndex, string name)
    {
        PlayerIndex = playerIndex;
        playerName = name;
        isMoving = false;
        // Eventuell annan initialisering f�r spelaren
    }
}



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
