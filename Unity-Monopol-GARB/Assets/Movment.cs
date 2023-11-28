using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monopoly
{
    public class Movment : MonoBehaviour
    {
        public List<Player> players; // Uppdaterat till att använda Player-klassen istället för GameObject
        public List<Street> board; // Uppdaterat till att använda Street-klassen istället för GameObject
        public Route currentRoute;
        public int steps;
        private List<int> routePositions;
        private List<Vector3> initialPositions;
        private int currentPlayerIndex = 0;
        private bool isMoving;

        void Start()
        {
            // Initialize players list or assign in the inspector
            players = new List<Player>
        {
            new Player { playerName = "Player1" },
            new Player { playerName = "Player2" },
            new Player { playerName = "Player3" },
            new Player { playerName = "Player4" }
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
            board = new List<Street>
    {
        new Street("Gå", 0), // Gå
        new Street("brun gata 1", 60),
        new SpecialSquare("Allmänning"), // Allmänning
        new Street("Brun gata 2", 80),
        new Street("Ljusblå gata 1", 100), // Skeppsbron
        new SpecialSquare("Chans"), // Chans
        new Street("Ljusblå gata 2", 100),
        new SpecialSquare("Ljusblå gata 3", 120),
        new CornerSquare("Hörn"), // Fängelse
        new Street("Rosa gata 1", 120),
        new Street("Rosa gata 2", 120),
        new Street("Rosa gata 3", 140),
        new Street("Orange gata 1", 140),
        new SpecialSquare("Allmänning"), // Allmänning
        new Street("Orange gata 2", 140),
        new Street("Orange gata 3", 160),
        new CornerSquare("fri parkering"),
        new Street("Röd gata 1", 160),
        new SpecialSquare("Chans"), // Chans
        new Street("Röd gata 2", 160),
        new Street("Röd gata 3", 180),
        new Street("Gul gata 1", 160),
        new Street("Gul gata 2", 160),
        new Street("Gul gata 3", 180),
        new CornerSquare("Gå till fängelse"), //fängelse
        new Street("Grön gata 1", 200),
        new Street("Grön gata 2", 200),
        new SpecialSquare("Allmänning"), // Allmänning
        new Street("Grön gata 3", 220),
        new SpecialSquare("Chans"), // Chans
        new Street("Blå gata 1", 350),
        new Street("Blå gata 2", 400),
    };
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
            {
                StartCoroutine(MovePlayer());
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

