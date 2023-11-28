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
            GameObject.Find("Allmänning 1"),
            GameObject.Find("Brun Gata 2"),
            GameObject.Find("Ljusblå Gata 1"),
            GameObject.Find("Chans 1"),
            GameObject.Find("Ljusblä Gata 2"),
            GameObject.Find("Ljusblä Gata 3"),
            GameObject.Find("Bara på besök"),
            GameObject.Find("Råsa Gata 1"),
            GameObject.Find("Råsa Gata 2"),
            GameObject.Find("Råsa Gata 3"),
            GameObject.Find("Orange Gata 1"),
            GameObject.Find("Allmänning 2"),
            GameObject.Find("Orange Gata 2"),
            GameObject.Find("Orange Gata 3"),
            GameObject.Find("Parkeringing"),
            GameObject.Find("Röd Gata 1"),
            GameObject.Find("Chans 2"),
            GameObject.Find("Röd Gata 2"),
            GameObject.Find("Röd Gata 3"),
            GameObject.Find("Gul Gata 1"),
            GameObject.Find("Gul Gata 2"),
            GameObject.Find("Gul Gata 3"),
            GameObject.Find("Gå i fängelse"),
            GameObject.Find("Grön Gata 1"),
            GameObject.Find("Grön Gata 2"),
            GameObject.Find("Allmänning 3"),
            GameObject.Find("Grön Gata 3"),
            GameObject.Find("Chans 3"),
            GameObject.Find("Blå Gata 1"),
            GameObject.Find("Blå Gata 2"),
        };
    }

    // Update is called once per frame
    void Update()
    {
        // Hantera spelarinput eller andra händelser här
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Exempel: Köp en gata när spelaren trycker på mellanslagstangenten
         //   blueStreet.BuyStreet(player);
        }

        // Uppdatera gränssnittet eller andra visuella element här
        //  UpdateUI();
    }
}
