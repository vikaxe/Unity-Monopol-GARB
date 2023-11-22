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
        // Hantera spelarinput eller andra händelser här
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Exempel: Köp en gata när spelaren trycker på mellanslagstangenten
            blueStreet.BuyStreet(player);
        }

        // Uppdatera gränssnittet eller andra visuella element här
        UpdateUI();
    }
}
