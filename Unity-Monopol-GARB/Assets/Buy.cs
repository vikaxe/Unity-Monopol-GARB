using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Monopoly
{
    public class Buy : MonoBehaviour
    {
        public GameObject buyWindow;

        private GameObject currentPlayer;
        private GameObject currentStreet;

        void Start()
        {
            CloseBuyWindow();
        }

        void Update()
        {
 
        }


        public void LandOnStreet(GameObject player, GameObject street)
        {
            currentPlayer = player;
            currentStreet = street;

            if (currentStreet != null)
            {
                Street streetComponent = currentStreet.GetComponent<Street>();

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
                else
                {
                    Debug.LogError("LandOnStreet: Street component is null for " + currentStreet.name);
                }
            }
            else
            {
                Debug.LogError("LandOnStreet: street parameter is null!");
            }

        }

        public bool IsBuyWindowActive()
        {
            return buyWindow.activeSelf;
        }

        public void HandleBuyDecisionYES()
        {
            currentStreet.GetComponent<Street>().BuyStreet(currentPlayer.GetComponent<Player>());
            Debug.Log("Pressed YES");
        }

        public void HandleBuyDecisionNO()
        {
            Debug.Log("Pressed NO");

            buyWindow.transform.Find("Köpa gata UI").gameObject.SetActive(false);
            CloseBuyWindow();

            GameManager.gameState = GameManager.GameState.WaitingForPlayerInput;
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


    }
}
