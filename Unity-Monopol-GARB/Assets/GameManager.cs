using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public enum GameState
    {
        WaitingForPlayerInput,
        PlayerMoving,
        // Add more states as needed
    }

    private static int currentPlayerIndex = 0;
    public static GameState gameState = GameState.WaitingForPlayerInput;

    public static Player GetCurrentPlayer()
    {
        return GameObject.Find("Player" + (currentPlayerIndex + 1)).GetComponent<Player>();
    }

    public static void MoveToNextPlayer()
    {
        currentPlayerIndex = (currentPlayerIndex + 1) % 4; // Assuming there are 4 players
        gameState = GameState.WaitingForPlayerInput;
    }
}
    

