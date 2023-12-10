using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monopoly
{
    public class GameManager : MonoBehaviour
    {
        public List<Street> board;
        public Buy buyScript;
        public Movement movementScript;
        private static int currentPlayerIndex = 0;
        public static GameState gameState = GameState.WaitingForPlayerInput;

        void Start()
        {
            InitializeBoard();
            buyScript = GetComponent<Buy>();
            movementScript = GetComponent<Movement>();
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

        void InitializeBoard()
        {
            board = new List<Street>{
                //kan behöva göra nya kalsser år sepcial rutor i framtiden
                GameObject.Find("Go").GetComponent<Street>(),
                GameObject.Find("Brun Gata 1").GetComponent<Street>(),
                GameObject.Find("AllmÄnning 1").GetComponent<Street>(),
                GameObject.Find("Brun Gata 2").GetComponent<Street>(),
                GameObject.Find("Ljusblå Gata 1").GetComponent<Street>(),
                GameObject.Find("Chans 1").GetComponent<Street>(),
                GameObject.Find("Ljusblå Gata 2").GetComponent<Street>(),
                GameObject.Find("Ljusblå Gata 3").GetComponent<Street>(),
                GameObject.Find("Bara på besök").GetComponent<Street>(),
                GameObject.Find("Råsa Gata 1").GetComponent<Street>(),
                GameObject.Find("Råsa Gata 2").GetComponent<Street>(),
                GameObject.Find("Råsa Gata 3").GetComponent<Street>(),
                GameObject.Find("Orange Gata 1").GetComponent<Street>(),
                GameObject.Find("Allmänning 2").GetComponent<Street>(),
                GameObject.Find("Orange Gata 2").GetComponent<Street>(),
                GameObject.Find("Orange Gata 3").GetComponent<Street>(),
                GameObject.Find("Parkering").GetComponent<Street>(),
                GameObject.Find("Röd Gata 1").GetComponent<Street>(),
                GameObject.Find("Chans 2").GetComponent<Street>(),
                GameObject.Find("Röd Gata 2").GetComponent<Street>(),
                GameObject.Find("Röd Gata 3").GetComponent<Street>(),
                GameObject.Find("Gul Gata 1").GetComponent<Street>(),
                GameObject.Find("Gul Gata 2").GetComponent<Street>(),
                GameObject.Find("Gul Gata 3").GetComponent<Street>(),
                GameObject.Find("Gå till fängelse").GetComponent<Street>(),
                GameObject.Find("Grön Gata 1").GetComponent<Street>(),
                GameObject.Find("Grön Gata 2").GetComponent<Street>(),
                GameObject.Find("Allmänning 3").GetComponent<Street>(),
                GameObject.Find("Grön Gata 3").GetComponent<Street>(),
                GameObject.Find("Chans 3").GetComponent<Street>(),
                GameObject.Find("Blå Gata 1").GetComponent<Street>(),
                GameObject.Find("Blå Gata 2").GetComponent<Street>(),
            };
        }

        void HandlePlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                HandleBuyDecision();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                buyScript.CloseBuyWindow();
            }
        }

        void HandleBuyDecision()
        {
            gameState = GameState.PlayerMoving;
            buyScript.ShowBuyPrompt();

            if (buyScript.buyWindow.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    buyScript.BuyStreet();
                    MoveToNextPlayer();
                }
                else if (Input.GetKeyDown(KeyCode.N))
                {
                    buyScript.CloseBuyWindow();
                    MoveToNextPlayer();
                }
            }
        }

        public static Player GetCurrentPlayer()
        {
            return GameObject.Find("Player" + (currentPlayerIndex + 1)).GetComponent<Player>();
        }

        public static void MoveToNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % 4; // Assuming there are 4 players
            gameState = GameState.WaitingForPlayerInput;
        }

        public enum GameState
        {
            WaitingForPlayerInput,
            PlayerMoving,
            // Add more states as needed
        }
    }
}
