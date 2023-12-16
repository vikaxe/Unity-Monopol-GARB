using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerIndex { get; private set; }
    public string playerName;
    public bool isMoving;
    public int cash = 1000;
    public Material playerMaterial;

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
        // Implementera logik för att sätta spelarens position till startpositionen
    }

    public void ResetMoney()
    {
        // Återställ spelarens pengar till startpengar
        cash = 1000;
    }

    public void SellAllStreets()
    {
        // Sälj alla gator som spelaren äger
        // Implementera logik för att sälja gatorna
    }
}





    
