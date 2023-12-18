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
                // Flytta spelaren till F�ngelserutan (Bara p� bes�k)
                player.MoveToJail();
                Debug.Log("Spealren landade p� G� i f�ngelse");
            }
        } 
         
    }
}

