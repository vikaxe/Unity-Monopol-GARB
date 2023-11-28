using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movment : MonoBehaviour
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

            // Skapa och initialisera gatorna h�r
            board = new List<Street>
    {
        new Street("G�", 0), // G�
        new Street("brun gata 1", 60),
        new SpecialSquare("Allm�nning"), // Allm�nning
        new Street("Brun gata 2", 80),
        new Street("Ljusbl� gata 1", 100), // Skeppsbron
        new SpecialSquare("Chans"), // Chans
        new Street("Ljusbl� gata 2", 100),
        new SpecialSquare("Ljusbl� gata 3", 120),
        new CornerSquare("H�rn"), // F�ngelse
        new Street("Rosa gata 1", 120),
        new Street("Rosa gata 2", 120),
        new Street("Rosa gata 3", 140),
        new Street("Orange gata 1", 140),
        new SpecialSquare("Allm�nning"), // Allm�nning
        new Street("Orange gata 2", 140),
        new Street("Orange gata 3", 160),
        new CornerSquare("fri parkering"),
        new Street("R�d gata 1", 160),
        new SpecialSquare("Chans"), // Chans
        new Street("R�d gata 2", 160),
        new Street("R�d gata 3", 180),
        new Street("Gul gata 1", 160),
        new Street("Gul gata 2", 160),
        new Street("Gul gata 3", 180),
        new CornerSquare("G� till f�ngelse"), //f�ngelse
        new Street("Gr�n gata 1", 200),
        new Street("Gr�n gata 2", 200),
        new SpecialSquare("Allm�nning"), // Allm�nning
        new Street("Gr�n gata 3", 220),
        new SpecialSquare("Chans"), // Chans
        new Street("Bl� gata 1", 350),
        new Street("Bl� gata 2", 400),
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

