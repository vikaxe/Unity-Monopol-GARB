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
                HandleSpacePressed();
            }
        }

        void HandleSpacePressed()
        {
            // Dra ett slumpmässigt kort från antingen Chans eller Allmänning
            Card drawnCard = DrawRandomCard();

            // Utför handlingen för det dragna kortet
            //drawnCard.PerformAction();
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

            public virtual void PerformAction(Player player)
            {
                // Grundläggande åtgärder för en specialruta
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
                //Card drawnCard = DrawRandomCard();
                //drawnCard.PerformAction();
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
                //Card drawnCard = DrawRandomCard();
                //drawnCard.PerformAction();
            }
        }

        public class Card
        {
            public string Name { get; private set; }

            public Card(string name)
            {
                Name = name;
            }

            public virtual void Execute(Player player)
            {
                // Implementera logik för vad som händer när kortet dras
            }
        }

        public class CollectMoneyCard : Card
        {
            public int Amount { get; private set; }

            public CollectMoneyCard(string name, int amount) : base(name)
            {
                Amount = amount;
            }

            public override void Execute(Player player)
            {
                //player.AddMoney(Amount);
                // Implementera eventuella ytterligare åtgärder
            }
        }

        public class MoveForwardCard : Card
        {
            public int Steps { get; private set; }

            public MoveForwardCard(string name, int steps) : base(name)
            {
                Steps = steps;
            }

            public override void Execute(Player player)
            {
                //player.MoveForward(Steps);
                // Implementera eventuella ytterligare åtgärder
            }
        }

        public class ResetCard : Card
        {
            public ResetCard(string name) : base(name)
            {
                // Anpassade inställningar för återställningskortet
            }

            //public override void Execute(Player player, List<Street> ownedStreets)
            //{
                // Återställ spelarens position till start
                //player.ResetPosition();

                // Återställ spelarens pengar till startpengar
                //player.ResetMoney();

                // Sälj alla gator som spelaren äger
                //foreach (var street in ownedStreets)
                //{
                //    street.SellStreet();
                //}
            //}
        }

        public class ChanceDeck
        {
            private List<Card> cards;

            public ChanceDeck()
            {
                cards = new List<Card>();
                InitializeDeck();
            }

            private void InitializeDeck()
            {
                // Lägg till kort med olika sannolikheter
                for (int i = 0; i < 60; i++) // 60/100 sannolikhet (60%)
                {
                    cards.Add(new CollectMoneyCard("Collect 300", 300));
                }

                for (int i = 0; i < 39; i++) // 39/100 sannolikhet (39%)
                {
                    cards.Add(new MoveForwardCard("Move 2 steps", 2));
                }

                for (int i = 0; i < 1; i++) // 1/100 sannolikhet (1%)
                {
                    cards.Add(new ResetCard("Reset the player"));
                }
            }

            public Card DrawRandomCard()
            {
                // Dra ett slumpmässigt kort från leken
                int randomIndex = UnityEngine.Random.Range(0, cards.Count);
                Card drawnCard = cards[randomIndex];
                cards.RemoveAt(randomIndex);

                return drawnCard;
            }
        }

        // Metod för att dra ett slumpmässigt kort
        private Card DrawRandomCard()
        {
            // Skapa en lista med möjliga kort
            List<Card> possibleCards = new List<Card>();

            // Lägg till kort med olika sannolikheter
            // Kort med högre sannolikhet bör läggas till fler gånger i listan
            possibleCards.Add(new CollectMoneyCard("Collect 300", 300));  // 5/10 sannolikhet
            possibleCards.Add(new MoveForwardCard("Move 2 steps", 2));      // 1/10 sannolikhet
            //possibleCards.Add(new SomeOtherCard("Some action"));           // Till exempel en annan typ av kort

            // Slumpa ett index för att välja ett kort från listan
            int randomIndex = Random.Range(0, possibleCards.Count);

            // Returnera det dragna kortet
            return possibleCards[randomIndex];
        }
    }
}





