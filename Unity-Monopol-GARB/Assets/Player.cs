using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Monopoly
{
    public class Player : MonoBehaviour
    {
        public int PlayerIndex { get; private set; }
        public string playerName;
        public bool isMoving;
        public int cash = 1000;
        public Material playerMaterial;
        public Route currentRoute;
        public Movement movementScript;
        public GoToJail goToJail;

        // Lägg till TurnsToSkip-egenskap
        private int turnsToSkip = 0;
        public int TurnsToSkip
        {
            get { return turnsToSkip; }
            set { turnsToSkip = value; }
        }

        public void InitializePlayer(int playerIndex, string name)
        {
            PlayerIndex = playerIndex;
            playerName = name;
            isMoving = false;
        }

        public void DeductCash(int amount)
        {
            cash -= amount;
            Debug.Log($"{playerName} deducted {amount} cash. Remaining cash: {cash}");
            // skapa koll om spelaren har tillräckligt med pengar senare
        }

        public void AddCash(int amount)
        {
            cash += amount;
            Debug.Log($"{playerName} deducted {amount} cash. Remaining cash: {cash}");
        }

        public void ResetToStart()
        {
            // Återställ spelaren till startpositionen
            //transform.position = initialPositions[PlayerIndex];
            //routePositions[PlayerIndex] = 0;
            Debug.Log($"{playerName} reset to start position.");
        }

        public void ResetMoney()
        {
            // Återställ spelarens pengar till startpengar
            cash = 1000;
        }

        public void SellAllStreets()
        {
            // Implementera logik för att sälja alla gator som spelaren äger
        }

        public void AddMoney(int amount)
        {
            cash += amount;
            Debug.Log($"{playerName} received {amount} money. New cash balance: {cash}");
        }

        public void MoveForward(int steps)
        {
            // Implementera logik för att flytta spelaren framåt med det angivna antalet steg
            // Exempel: transform.Translate(Vector3.forward * steps);
            Debug.Log($"{playerName} moved forward {steps} steps.");
        }

        public void MoveToJail()
        {
            // Implementera logik för att flytta spelaren till fängelset
            // Till exempel, sätt spelarens position till fängelset positionen
            

            TurnsToSkip = 2; // Sätt TurnsToSkip till 2
            Debug.Log("Du kan inte röra dig på 2 rundor");
        }

        // Lägg till DecrementTurnsToSkip-metod
        public void DecrementTurnsToSkip()
        {
            turnsToSkip = Mathf.Max(0, turnsToSkip - 1);
        }
    }

}
