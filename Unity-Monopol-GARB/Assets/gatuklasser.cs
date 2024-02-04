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
            private ChanceDeck chanceDeck; // Lägg till en referens till ChanceDeck

            public Chans(string name, ChanceDeck chanceDeck) : base(name)
            {
                // Anpassade inställningar för Chans
                this.chanceDeck = chanceDeck;
            }

            public override void PerformAction(Player player)
            {
                // Exempel: Spelaren drar ett slumpmässigt "Chans"-kort och agerar baserat på kortet
                Card drawnCard = chanceDeck.DrawRandomCard();
                drawnCard.Execute(player);
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
                player.AddMoney(Amount);
                Debug.Log($"{player.playerName} erhåller {Amount} pengar.");
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
                player.MoveForward(Steps);
                Debug.Log($"{player.playerName} moves {Steps} steps forward.");
            }
        }

        public class ResetCard : Card
        {
            public ResetCard(string name) : base(name)
            {
                // Anpassade inställningar för återställningskortet
            }

            public override void Execute(Player player)
            {

                //Återställ spelarens pengar till startpengar
                player.ResetMoney();

                // Sälj alla gator som spelaren äger
                player.SellAllStreets();
            }
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


        public class GoSquare
        {
            public GoSquare(string name)
            {

            }

            public int goReward = 200; // Antal pengar spelaren får när de passerar Gå-rutan

            // Metod som kallas när spelaren passerar Gå-rutan
            public void HandleGo(Player player)
            {
                // Anropa AddMoney-metoden i Player-klassen för att ge spelaren pengar
                player.AddMoney(goReward);

                // Skriv ut information i loggen
                Debug.Log($"{player.playerName} passerade Gå-rutan och erhöll {goReward} pengar.");
            }
        }

        public class FreeParkingSquare 
        {
            public FreeParkingSquare(string name)
            {

            }

            public void LandOn(Player player)
            {
                // Ingenting händer på Fri parkering
            }
        }

        
    }
}





