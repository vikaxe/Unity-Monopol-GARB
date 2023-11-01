using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] childObjects; // En array som kommer att användas för att lagra alla Transform-komponenter (position och rotation) av barnobjekt.
    public List<Transform> childNodeList = new List<Transform>(); // En lista som kommer att innehålla Transform-komponenter av gat-noderna(gatorna).

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Sätter färgen för Gizmos, som används för att visualisera vägen i scenen.

        FillNodes(); // Anropar FillNodes-metoden för att fylla listan childNodeList med gat-noderna(gatorna).

        for (int i = 0; i < childNodeList.Count; i++) // Loopar genom varje gat-nod(gatorna) i listan.
        {
            Vector3 currentPos = childNodeList[i].position; // Hämtar positionen (Transform) för den aktuella gat-noden(gatan).

            if (i > 0)
            {
                Vector3 prevPos = childNodeList[i - 1].position; // Hämtar positionen (Transform) för den föregående gat-noden.

                Gizmos.DrawLine(currentPos, prevPos); // Använder Gizmos för att rita en linje mellan den aktuella noden och den föregående noden för att visualisera vägen.
            }
        }
    }

    void FillNodes()
    {
        childNodeList.Clear(); // Rensar listan av gat-noder för att undvika duplicering.

        childObjects = GetComponentsInChildren<Transform>(); // Hämtar alla barnobjektens Transform-komponenter i detta spelobjekt och lagrar dem i childObjects-arrayen.

        foreach (Transform child in childObjects) // Loopar igenom varje Transform-komponent i childObjects-arrayen.
        {
            if (child != this.transform)
            {
                childNodeList.Add(child); // Lägger till Transform-komponenten i listan childNodeList om det inte är den egna Transform-komponenten (detta spelobjekt).
            }
        }
    }
}
