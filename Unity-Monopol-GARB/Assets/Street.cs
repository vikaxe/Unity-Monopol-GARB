using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monopoly;

public class Street : MonoBehaviour

{
    public Player Owner;
    public int purchasePrice = 1000;
    public Material defaultMaterial;

    public void SetOwner(Player newOwner)
    {
        Owner = newOwner;
    }

    public void BuyStreet(Player currentPlayer)
    {

        if (Owner == null)
        {
            SetOwner(currentPlayer);
            currentPlayer.DeductCash(purchasePrice);
            Debug.Log($"{currentPlayer.playerName} har k�pt {gameObject.name} f�r {purchasePrice} kr.");

            Renderer streetRenderer = GetComponent<Renderer>();
            if (streetRenderer != null)
            {
                Material playerMaterial = currentPlayer.playerMaterial;
                streetRenderer.material = playerMaterial;
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} �r redan �gd av {Owner.playerName}.");
        }
    }
}
