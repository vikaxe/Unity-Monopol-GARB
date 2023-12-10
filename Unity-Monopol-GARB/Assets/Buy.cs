using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Monopoly
{
    public class Buy : MonoBehaviour
    {
        public GameObject buyWindow;
        public Text promptText;

        private GameObject currentPlayer;
        private GameObject currentStreet;

        void Start()
        {
            CloseBuyWindow();
        }

        void Update()
        {
            if (GameManager.gameState == GameManager.GameState.WaitingForPlayerInput)
            {
                if (buyWindow.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.Y))
                    {
                        Debug.Log("Pressed 'Y' inside Buy Window");
                        BuyStreet();
                        GameManager.MoveToNextPlayer();
                    }
                    else if (Input.GetKeyDown(KeyCode.N))
                    {
                        Debug.Log("Pressed 'N' inside Buy Window");
                        CloseBuyWindow();
                        GameManager.MoveToNextPlayer();
                    }
                }
                else
                {
                    // Check for the 'E' key to show the buy window
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Pressed 'E' to show Buy Prompt");
                        ShowBuyPrompt();
                        GameManager.gameState = GameManager.GameState.PlayerMoving;
                    }
                    else if (Input.GetKeyDown(KeyCode.R))
                    {
                        Debug.Log("Pressed 'R' to close Buy Window");
                        CloseBuyWindow();
                    }
                }
            }
        }


        public void LandOnStreet(GameObject player, GameObject street)
        {
            currentPlayer = player;
            currentStreet = street;

            Player owner = currentStreet.GetComponent<Street>().Owner;

            if (owner == null)
            {
                SetPromptText("Do you want to buy this street? Press 'Y' for Yes, 'N' for No.");
                OpenBuyWindow();
            }
            else
            {
                Debug.Log("Street is owned by: " + owner.playerName + ". Pay rent.");
            }
        }

        public void HandleBuyDecision()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                BuyStreet();
                GameManager.MoveToNextPlayer();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                CloseBuyWindow();
                GameManager.MoveToNextPlayer();
            }
        }

        public void BuyStreet()
        {
            currentStreet.GetComponent<Street>().BuyStreet(currentPlayer.GetComponent<Player>());
            CloseBuyWindow();
        }

        public void OpenBuyWindow()
        {
            buyWindow.SetActive(true);
        }

        public void CloseBuyWindow()
        {
            buyWindow.SetActive(false);
        }

        public void SetPromptText(string text)
        {
            promptText.text = text;
        }

        public void ShowBuyPrompt()
        {
            SetPromptText("Do you want to buy a street? Press 'Y' for Yes, 'N' for No. På skriv bordet");
            OpenBuyWindow();
        }
    }
}
