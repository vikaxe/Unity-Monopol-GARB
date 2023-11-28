using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buy : MonoBehaviour
{
    public GameObject buyWindow;
    public Text promptText;

    private GameObject currentPlayer;
    private GameObject currentStreet;

    void Start()
    {
        buyWindow.SetActive(false);
    }

    public void LandOnStreet(GameObject player, GameObject street)
    {
        currentPlayer = player;
        currentStreet = street;

        // Check if the street is owned by someone
        Player owner = currentStreet.GetComponent<Street>().Owner;

        if (owner == null)
        {
            // The street is not owned, prompt the player to buy it
            promptText.text = "Do you want to buy this street? Press 'Y' for Yes, 'N' for No.";
            buyWindow.SetActive(true);
        }
        else
        {
            // The street is owned, pay rent
            // You can implement this logic here
            Debug.Log("Street is owned by: " + owner.playerName + ". Pay rent.");
        }
    }

    void Update()
    {
        if (buyWindow.activeSelf)
        {
            // Handle player input for buying the street
            if (Input.GetKeyDown(KeyCode.Y))
            {
                BuyStreet();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                // Player chooses not to buy the street
                CloseBuyWindow();
            }
        }
    }

    void BuyStreet()
    {
        // Purchase the street
        currentStreet.GetComponent<Street>().SetOwner(currentPlayer.GetComponent<Player>());
        currentPlayer.GetComponent<Player>().cash -= currentStreet.GetComponent<Street>().purchasePrice;

        // Close the buy window
        CloseBuyWindow();
    }

    void CloseBuyWindow()
    {
        buyWindow.SetActive(false);
    }
}
