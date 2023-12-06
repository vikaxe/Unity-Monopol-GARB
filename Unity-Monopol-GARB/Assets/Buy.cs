using Monopoly;
using UnityEngine;
using UnityEngine.UI;

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

    void Update()
    {
        // Check for the 'E' key to show the buy window
        if (GameManager.gameState == GameManager.GameState.WaitingForPlayerInput)
        {
            // Check for the 'E' key to show the buy window
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowBuyPrompt();
                GameManager.gameState = GameManager.GameState.PlayerMoving; // Player is making a decision, disable others
            }

            // Check for player input when the buy window is active
            if (buyWindow.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    BuyStreet();
                    GameManager.MoveToNextPlayer(); // Move to the next player after the decision
                }
                else if (Input.GetKeyDown(KeyCode.N))
                {
                    CloseBuyWindow();
                    GameManager.MoveToNextPlayer(); // Move to the next player after the decision
                }
            }
        }
    }

    void BuyStreet()
    {
        currentStreet.GetComponent<Street>().BuyStreet(currentPlayer.GetComponent<Player>());
        CloseBuyWindow();
    }

    void OpenBuyWindow()
    {
        buyWindow.SetActive(true);
    }

    void CloseBuyWindow()
    {
        buyWindow.SetActive(false);
    }

    void SetPromptText(string text)
    {
        promptText.text = text;
    }

    // Method to show the buy prompt without landing on a street
    void ShowBuyPrompt()
    {
        // Customize the prompt message as needed
        SetPromptText("Do you want to buy a street? Press 'Y' for Yes, 'N' for No. På skriv bordet");

        OpenBuyWindow();
    }
}