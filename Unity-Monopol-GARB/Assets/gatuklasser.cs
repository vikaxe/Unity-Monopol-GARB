using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatuklasser : MonoBehaviour
{
    public List<GameObject> gator;
    // Start is called before the first frame update
    void Start()
    {
        gator = new List<GameObject>
        {
            GameObject.Find("Go"),
            GameObject.Find("Brun Gata 1"),
            GameObject.Find("Allm�nning 1"),
            GameObject.Find("Brun Gata 2"),
            GameObject.Find("Ljusbl� Gata 1"),
            GameObject.Find("Chans 1"),
            GameObject.Find("Ljusbl� Gata 2"),
            GameObject.Find("Ljusbl� Gata 3"),
            GameObject.Find("Bara p� bes�k"),
            GameObject.Find("R�sa Gata 1"),
            GameObject.Find("R�sa Gata 2"),
            GameObject.Find("R�sa Gata 3"),
            GameObject.Find("Orange Gata 1"),
            GameObject.Find("Allm�nning 2"),
            GameObject.Find("Orange Gata 2"),
            GameObject.Find("Orange Gata 3"),
            GameObject.Find("Parkeringing"),
            GameObject.Find("R�d Gata 1"),
            GameObject.Find("Chans 2"),
            GameObject.Find("R�d Gata 2"),
            GameObject.Find("R�d Gata 3"),
            GameObject.Find("Gul Gata 1"),
            GameObject.Find("Gul Gata 2"),
            GameObject.Find("Gul Gata 3"),
            GameObject.Find("G� i f�ngelse"),
            GameObject.Find("Gr�n Gata 1"),
            GameObject.Find("Gr�n Gata 2"),
            GameObject.Find("Allm�nning 3"),
            GameObject.Find("Gr�n Gata 3"),
            GameObject.Find("Chans 3"),
            GameObject.Find("Bl� Gata 1"),
            GameObject.Find("Bl� Gata 2"),
        };
    }

    // Update is called once per frame
    void Update()
    {
        // Hantera spelarinput eller andra h�ndelser h�r
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Exempel: K�p en gata n�r spelaren trycker p� mellanslagstangenten
         //   blueStreet.BuyStreet(player);
        }

        // Uppdatera gr�nssnittet eller andra visuella element h�r
        //  UpdateUI();
    }
}
