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

    public List<Player> players = new List<Player>();
    private int currentPlayerIndex = 0;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)// "Sl�r t�rning n�r man trycker p� space och inte redan r�r p� sig"
        {
            steps = Random.Range(1, 7);// T�rning - genererar ett slumptal mellan 1 och 6 (som en t�rning) och lagrar det i 'steps'.
            Debug.Log("Player " + (currentPlayerIndex + 1) + " rolled " + steps);// Skriver ut t�rningens resultat i konsolen och vilken spelare.

            StartCoroutine(Move()); // Startar r�relsen genom att anv�nda en Coroutine f�r att undvika att blockera hela spelet.
        }
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;// Om objektet redan �r i r�relse, avsluta Coroutine.
        }
        isMoving = true;// S�tter flaggan 'isMoving' till true f�r att f�rhindra flera r�relser samtidigt.

        while (steps > 0)
        {
            routePosition++;
            routePosition %= currentRoute.childNodeList.Count;// Loopar genom GatorNanoderna(gatorna).

            Vector3 nextPos = currentRoute.childNodeList[routePosition].position;// H�mtar n�sta m�lposition fr�n gatnoderna.
            while (MoveToNextNode(nextPos))
            {
                yield return null; // R�r objektet mot n�sta m�lposition stegvis och avbryter n�r det har n�tt den.
            }
            yield return new WaitForSeconds(0.1f);// V�ntar i 0.1 sekunder mellan stegen.
            steps--; // Minskar antalet steg kvar att r�ra sig.

            if (steps == 0)
            {
                isMoving = false;
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;//byter till n�sta spelare
            }

        }
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
        // R�r objektet mot det n�sta m�let. Returnerar true om m�let inte har n�tts �n, annars returnerar false.
    }

}