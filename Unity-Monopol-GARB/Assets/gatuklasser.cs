using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monopoly
{
    public class gatuklasser : MonoBehaviour
    {
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
                // Implementera logik f�r n�r en spelare landar p� gatan
            }
        }
        public class SpecialSquare : Street
        {
            public SpecialSquare(string name) : base(name, 0)
            {
                // SpecialSquare kostar ingenting att k�pa
            }

            public override void LandOn(Player player)
            {
                // Implementera logik f�r n�r en spelare landar p� Allm�nning eller Chans
            }
        }
        public class CornerSquare : Street
        {
            public CornerSquare(string name) : base(name, 0)
            {
                // CornerSquare kostar ingenting att k�pa
            }

            public override void LandOn(Player player)
            {
                // Implementera logik f�r n�r en spelare landar p� ett h�rn
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // Eventuell logik f�r Update-metoden
        }
    }
}



