using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movment : MonoBehaviour
{
    
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    public Route currentRoute;
    int routePosition;
    public int steps;
    bool isMoving;


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isMoving)// "Slår tärning när man trycker på space och inte redan rör på sig"
            {
                steps = Random.Range(1, 7);// Tärning - genererar ett slumptal mellan 1 och 6 (som en tärning) och lagrar det i 'steps'.
                Debug.Log("Dice Rolled " + steps); // Skriver ut tärningens resultat i konsolen.

                StartCoroutine(Move()); // Startar rörelsen genom att använda en Coroutine för att undvika att blockera hela spelet.
            }
        }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;// Om objektet redan är i rörelse, avsluta Coroutine.
        }
        isMoving = true;// Sätter flaggan 'isMoving' till true för att förhindra flera rörelser samtidigt.

        while (steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;// Loopar genom GatorNanoderna(gatorna).

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;// Hämtar nästa målposition från gatnoderna.
            while (MoveToNextNode(nextPos))
            {
                yield return null; // Rör objektet mot nästa målposition stegvis och avbryter när det har nått den.
            }
            yield return new WaitForSeconds(0.1f);// Väntar i 0.1 sekunder mellan stegen.
            steps--; // Minskar antalet steg kvar att röra sig.


        }
        isMoving = false;// Sätter 'isMoving' tillbaka till false när rörelsen är klar.
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
        // Rör objektet mot det nästa målet. Returnerar true om målet inte har nåtts än, annars returnerar false.
    }

}
