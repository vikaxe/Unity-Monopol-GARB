using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public List<GameObject> players;
    public Route currentRoute;
    public int steps;
    private List<int> routePositions;
    private List<Vector3> initialPositions;
    private int currentPlayerIndex = 0;
    private bool isMoving;

    void Start()
    {
        // Initialize players list or assign in the inspector
        players = new List<GameObject>
        {
            GameObject.Find("Player1"),
            GameObject.Find("Player2"),
            GameObject.Find("Player3"),
            GameObject.Find("Player4")
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)//kollar om man tryckt på space och att det inte är någon annan som rör sig
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
        GameObject currentPlayer = players[currentPlayerIndex];
        // Roll the dice
        steps = Random.Range(1, 7);
        Debug.Log("Player " + (currentPlayerIndex + 1) + " rolled " + steps);

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