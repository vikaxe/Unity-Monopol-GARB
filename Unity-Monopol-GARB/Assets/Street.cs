using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Street : MonoBehaviour


    //Enskilda gator
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player Owner;
    public double purchasePrice = 200; // You can adjust the purchase price as needed

    public void SetOwner(Player newOwner)
    {
        Owner = newOwner;
    }
}
