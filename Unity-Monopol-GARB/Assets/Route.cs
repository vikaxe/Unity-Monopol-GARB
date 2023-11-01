using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] childObjects; // En array som kommer att anv�ndas f�r att lagra alla Transform-komponenter (position och rotation) av barnobjekt.
    public List<Transform> childNodeList = new List<Transform>(); // En lista som kommer att inneh�lla Transform-komponenter av gat-noderna(gatorna).

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // S�tter f�rgen f�r Gizmos, som anv�nds f�r att visualisera v�gen i scenen.

        FillNodes(); // Anropar FillNodes-metoden f�r att fylla listan childNodeList med gat-noderna(gatorna).

        for (int i = 0; i < childNodeList.Count; i++) // Loopar genom varje gat-nod(gatorna) i listan.
        {
            Vector3 currentPos = childNodeList[i].position; // H�mtar positionen (Transform) f�r den aktuella gat-noden(gatan).

            if (i > 0)
            {
                Vector3 prevPos = childNodeList[i - 1].position; // H�mtar positionen (Transform) f�r den f�reg�ende gat-noden.

                Gizmos.DrawLine(currentPos, prevPos); // Anv�nder Gizmos f�r att rita en linje mellan den aktuella noden och den f�reg�ende noden f�r att visualisera v�gen.
            }
        }
    }

    void FillNodes()
    {
        childNodeList.Clear(); // Rensar listan av gat-noder f�r att undvika duplicering.

        childObjects = GetComponentsInChildren<Transform>(); // H�mtar alla barnobjektens Transform-komponenter i detta spelobjekt och lagrar dem i childObjects-arrayen.

        foreach (Transform child in childObjects) // Loopar igenom varje Transform-komponent i childObjects-arrayen.
        {
            if (child != this.transform)
            {
                childNodeList.Add(child); // L�gger till Transform-komponenten i listan childNodeList om det inte �r den egna Transform-komponenten (detta spelobjekt).
            }
        }
    }
}
