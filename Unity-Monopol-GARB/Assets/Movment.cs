using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monopoly
{
    public class Movement : MonoBehaviour
    {
        public List<Player> players;
        private List<int> routePositions;
        private List<Vector3> initialPositions;
        public Route currentRoute;
        private int currentPlayerIndex = 0;
        private bool isMoving;
        public int steps;
        public Buy buyScript;

        void Start()
        {
            routePositions = new List<int>(players.Count);
            for (int i = 0; i < players.Count; i++)
            {
                routePositions.Add(0);
            }

            initialPositions = new List<Vector3>();
            foreach (var player in players)
            {
                initialPositions.Add(player.transform.position);
            }
        }

        public void StartPlayerMovement()
        {
            if (!buyScript.IsBuyWindowActive() ||!buyScript.IsRentWindowActive())
            {
                StartCoroutine(MovePlayer());
            }
            else
            {
                Debug.Log("Kan inte röra dig. Buy eller rent window är kativ.");
            }
        }

        IEnumerator MovePlayer()
        {
            if (isMoving)
            {
                yield break;
            }
            isMoving = true;

            Player currentPlayer = players[currentPlayerIndex];
            steps = Random.Range(1, 7);
            Debug.Log($"{currentPlayer.playerName} rullade {steps}");

            while (steps > 0)
            {
                routePositions[currentPlayerIndex]++;
                routePositions[currentPlayerIndex] %= currentRoute.childNodeList.Count;

                Vector3 nextPos = currentRoute.childNodeList[routePositions[currentPlayerIndex]].position;
                

                while (MoveToNextNode(currentPlayer.transform, nextPos))
                {
                    yield return null;
                }

                yield return new WaitForSeconds(0.1f);
                steps--;

                if (steps == 0)
                {
                    Transform stoppedNode = currentRoute.childNodeList[routePositions[currentPlayerIndex]];
                    string stoppedNodeName = stoppedNode.name;
                    Debug.Log($"{currentPlayer.playerName} stanade vid node: {stoppedNodeName}");

                    
                    isMoving = false;

                    Street stoppedStreet = stoppedNode.GetComponent<Street>();
                    if (stoppedStreet != null)
                    {
                        Player owner = stoppedStreet.Owner;

                        if (owner == null)
                        {

                            buyScript.LandOnStreet(players[currentPlayerIndex].gameObject, stoppedNode.gameObject);
                            buyScript.OpenBuyWindow();

                            int streetCost = stoppedStreet.purchasePrice;
                            int playerCash = currentPlayer.cash;

                            if (playerCash < streetCost)
                            {
                                Debug.Log($"{currentPlayer.playerName} Inte tillräckligt med pengar. Nästa spelare.");
                                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
                                buyScript.CloseBuyWindow();
                            }
                        }
                        if (owner != null)
                        {
                            buyScript.CloseBuyWindow();
                            buyScript.LandOnStreet(players[currentPlayerIndex].gameObject, stoppedNode.gameObject);
                            buyScript.OpenRentWindow();
                        }
                    }
                    currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
                }
            }
        }

        bool MoveToNextNode(Transform playerTransform, Vector3 goal)
        {
            return goal != (playerTransform.position = Vector3.MoveTowards(playerTransform.position, goal, 2f * Time.deltaTime));
        }
    }
}
