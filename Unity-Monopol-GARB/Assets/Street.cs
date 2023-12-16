using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monopoly;

public class Street : MonoBehaviour

{
    public Player Owner;
    public int purchasePrice = 200;
    public string streetName;

    public void SetOwner(Player newOwner)
    {
        Owner = newOwner;
    }

    public void BuyStreet(Player currentPlayer)
    {
        if (Owner == null)
        {
            SetOwner(currentPlayer);
            currentPlayer.cash -= purchasePrice;
            Debug.Log(currentPlayer.playerName + " har köpt " + gameObject.name + " för " + purchasePrice + " kr.");
        }
        else
        {
            Debug.Log(gameObject.name + " är redan ägd " + Owner.playerName + ".");
        }

        
    }
}
