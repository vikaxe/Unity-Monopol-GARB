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

        public GameObject currentPlayer;
        public GameObject currentStreet;

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
                        Debug.Log("Gatan är ägd av: " + owner.playerName + ". Betala hyra.");
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
            CloseBuyWindow();
        }

        public void HandleBuyDecisionNO()
        {
            buyWindow.transform.Find("Köpa gata UI").gameObject.SetActive(false);
            CloseBuyWindow();
        }

        public void HandelBetalaHyra()
        {
            Debug.Log("Tryckte betala");

            Street streetComponent = currentStreet.GetComponent<Street>();
            if (streetComponent != null && streetComponent.Owner != null)
            {
                Player owner = streetComponent.Owner;
                int rentAmount = 50; 

                currentPlayer.GetComponent<Player>().DeductCash(rentAmount);
                owner.AddCash(rentAmount);

                Debug.Log($"{currentPlayer.GetComponent<Player>().playerName} betalade {rentAmount} hyra till {owner.playerName}.");
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
