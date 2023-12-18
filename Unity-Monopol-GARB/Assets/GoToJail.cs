using Monopoly;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Monopoly
{
    public class GoToJail : MonoBehaviour
    {
        // Start is called before the first frame update
        public class GoToJailSquare
        {
            public GoToJailSquare jailSquare;
            public Movement movement;
            public Route currentRoute;

            public void LandOnJail(Player player)
            {
                // Flytta spelaren till Fängelserutan (Bara på besök)
                player.MoveToJail();
                Debug.Log("Spealren landade på Gå i fängelse");
            }
        } 
         
    }
}

