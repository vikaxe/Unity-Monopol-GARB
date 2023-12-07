using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monopoly
{
    public class gatuklasser : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {
            // Hantera spelarinput eller andra händelser här
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Utför handlingar när space trycks ned
            }
        }

        public class Street
        {

            public string Name { get; private set; }
            public int Cost { get; private set; }

            public Street(string name, int cost)
            {
                Name = name;
                Cost = cost;
            }

            public virtual void LandOn(Player player)
            {
                // Implementera logik för när en spelare landar på gatan
            }
        }

        public class SpecialSquare : Street
        {
            public SpecialSquare(string name) : base(name, 0)
            {
                // SpecialSquare kostar ingenting att köpa
            }

            public override void LandOn(Player player)
            {
                // Implementera logik för när en spelare landar på Allmänning eller Chans
            }
        }

        public class Allmänning : SpecialSquare
        {
            public Allmänning(string name) : base(name)
            {
                // Anpassade inställningar för Allmänning
            }

            public override void PerformAction(Player player)
            {
                // Implementera specifika åtgärder för Allmänning
                // Exempel: Spelaren drar ett kort och gör något baserat på kortet
            }
        }

        public class Chans : SpecialSquare
        {
            public Chans(string name) : base(name)
            {
                // Anpassade inställningar för Chans
            }

            public override void PerformAction(Player player)
            {
                // Implementera specifika åtgärder för Chans
                // Exempel: Spelaren drar ett slumpmässigt "Chans"-kort och agerar baserat på kortet
            }
        }

        public class CornerSquare : Street
        {
            public CornerSquare(string name) : base(name, 0)
            {
                // CornerSquare kostar ingenting att köpa
            }

            public override void LandOn(Player player)
            {
                // Implementera logik för när en spelare landar på ett hörn
            }
        }

       
    }
}




