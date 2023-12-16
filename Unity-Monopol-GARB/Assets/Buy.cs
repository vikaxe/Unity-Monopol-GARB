using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Monopoly
{
    public class Buy : MonoBehaviour
    {
        public GameObject buyWindow;
        public GameObject rentWindow;

        private GameObject currentPlayer;
        private GameObject currentStreet;

        void Start()
        {
            CloseBuyWindow();
            CloseRentWindow();
        }

        public void LandOnStreet(GameObject player, GameObject street)
        {
            currentPlayer = player;
            currentStreet = street;

            if (currentStreet != null)
            {
                Street streetComponent = currentStreet.GetComponent<Street>();
                buyWindow.transform.Find("Köpa gata UI").gameObject.SetActive(false);
                rentWindow.transform.Find("Betala hyra UI").gameObject.SetActive(false);

                if (streetComponent != null)
                {
                    Player owner = streetComponent.Owner;

                    if (owner == null)
                    {
                        OpenBuyWindow();
                    }
                    else
                    {
                        Debug.Log("Street is owned by: " + owner.playerName + ". Pay rent.");
                    }
                }
            }
        }

        public bool IsBuyWindowActive()
        {
            return buyWindow.activeSelf;
        }
        public bool IsRentWindowActive()
        {
            return rentWindow.activeSelf;
        }

        public void HandleBuyDecisionYES()
        {
            currentStreet.GetComponent<Street>().BuyStreet(currentPlayer.GetComponent<Player>());
            Debug.Log("Pressed YES");
            CloseBuyWindow();
        }

        public void HandleBuyDecisionNO()
        {
            Debug.Log("Pressed NO");

            buyWindow.transform.Find("Köpa gata UI").gameObject.SetActive(false);
            CloseBuyWindow();

            GameManager.gameState = GameManager.GameState.WaitingForPlayerInput;
        }

        public void HandelBetalaHyra()
        {
            Debug.Log("Pressed Betala");

            Street streetComponent = currentStreet.GetComponent<Street>();
            if (streetComponent != null && streetComponent.Owner != null)
            {
                Player owner = streetComponent.Owner;
                int rentAmount = 50; // You can set the rent amount as needed

                // Deduct rent from the current player and add it to the owner's cash
                currentPlayer.GetComponent<Player>().DeductCash(rentAmount);
                owner.GetComponent<Player>().AddCash(rentAmount);

                Debug.Log($"{currentPlayer.GetComponent<Player>().playerName} paid {rentAmount} rent to {owner.playerName}.");
            }
            CloseRentWindow();
        }

        public void OpenBuyWindow()
        {

            buyWindow.transform.Find("Köpa gata UI").gameObject.SetActive(true);
            if (buyWindow != null)
            {
                buyWindow.SetActive(true);
            }
        }
        public void CloseBuyWindow()
        {
            if (buyWindow != null)
            {
                buyWindow.SetActive(false);
            }
        }


        public void OpenRentWindow()
        {

            rentWindow.transform.Find("Betala hyra UI").gameObject.SetActive(true);
            if (rentWindow != null)
            {
                rentWindow.SetActive(true);

            }
        }
        public void CloseRentWindow()
        {
            if (rentWindow != null)
            {
                rentWindow.SetActive(false);
            }
        }


    }
}
