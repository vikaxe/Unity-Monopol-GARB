using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatuklasser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Hantera spelarinput eller andra h�ndelser h�r
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Exempel: K�p en gata n�r spelaren trycker p� mellanslagstangenten
            blueStreet.BuyStreet(player);
        }

        // Uppdatera gr�nssnittet eller andra visuella element h�r
        UpdateUI();
    }
}
