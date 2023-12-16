using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Monopoly
{
    public class GameManager : MonoBehaviour
    {
        public List<Street> board;
        public Buy buyScript;
        public Movement movementScript;
        private static int currentPlayerIndex = 0;
        public static GameState gameState = GameState.WaitingForPlayerInput;

        public GameObject Route;
        public Player[] playerComponents;

        void Start()
        {

            buyScript = GetComponent<Buy>();
            movementScript = GetComponent<Movement>();

            Route = transform.GetChild(0)?.gameObject;

            int routeChildCount = Route.transform.childCount;

            // Log information about Route children
            for (int i = 0; i < routeChildCount; i++)
            {
                GameObject childObject = Route.transform.GetChild(i).gameObject;
                Debug.Log($"Route Child[{i}]: {childObject.name}");
            }
            for (int i = 1; i <= 4; i++)
            {
                string playerName = "Player" + i;
                Player playerComponent = GameObject.Find(playerName)?.GetComponent<Player>();

                Debug.Log($"Initialized {playerName}");
                
            }
        }
        

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && gameState == GameState.WaitingForPlayerInput)
            {
                movementScript.StartPlayerMovement();
            }

            if (gameState == GameState.WaitingForPlayerInput)
            {
                HandlePlayerInput();
            }
        }

        

        void HandlePlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HandleBuyDecision();
            }
        }

        void HandleBuyDecision()
        {
            gameState = GameState.PlayerMoving;


        }

        public static Player GetCurrentPlayer()
        {
            return GameObject.Find("Player" + (currentPlayerIndex + 1)).GetComponent<Player>();
        }

        public static void MoveToNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % 4;
            gameState = GameState.WaitingForPlayerInput;
        }

        public enum GameState
        {
            WaitingForPlayerInput,
            PlayerMoving,
        }
    }
}
