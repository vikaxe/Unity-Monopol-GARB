using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Monopoly
{
    public class Movment : MonoBehaviour
    {
        public List<Player> players; // Uppdaterat till att anv�nda Player-klassen ist�llet f�r GameObject
        public List<Street> board; // Uppdaterat till att anv�nda Street-klassen ist�llet f�r GameObject
        public Route currentRoute;
        public int steps;
        private List<int> routePositions;
        private List<Vector3> initialPositions;
        private int currentPlayerIndex = 0;
        private bool isMoving;

        public Buy buyScript;

        void Start()
        {

            buyScript = GetComponent<Buy>();
            // Initialize players list or assign in the inspector
            players = new List<Player>
            {
                GameObject.Find("Player1").GetComponent<Player>(),
                GameObject.Find("Player2").GetComponent<Player>(),
                GameObject.Find("Player3").GetComponent<Player>(),
                GameObject.Find("Player4").GetComponent<Player>()
            };

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

            // Skapa och initialisera gatorna här
            board = new List<Street>{
                //kan behöva göra nya kalsser år sepcial rutor i framtiden
                GameObject.Find("Go").GetComponent<Street>(),
                GameObject.Find("Brun Gata 1").GetComponent<Street>(),
                GameObject.Find("AllmÄnning").GetComponent<Street>(),
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

        void Update()
        {
            if (GameManager.gameState == GameManager.GameState.WaitingForPlayerInput)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
                {
                    StartCoroutine(MovePlayer());
                }
            }
        }

        IEnumerator MovePlayer()
        {
            if (isMoving)
            {
                yield break;
            }
            isMoving = true;

            // Get the current player
            Player currentPlayer = players[currentPlayerIndex];
            // Roll the dice
            steps = Random.Range(1, 7);
            Debug.Log($"{currentPlayer.playerName} rolled {steps}");

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
                    currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
                    isMoving = false;
                }
            }

        }

        bool MoveToNextNode(Transform playerTransform, Vector3 goal)
        {
            return goal != (playerTransform.position = Vector3.MoveTowards(playerTransform.position, goal, 2f * Time.deltaTime));
        }


       
    }
}
    

