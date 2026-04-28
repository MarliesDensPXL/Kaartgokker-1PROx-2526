namespace Kaartgokker
{
    internal class Program
    {
        static List<Card> _cardDeck = new List<Card>()
{
    new Card(){ Color="Rood", Name = "Harten 1" },
    new Card(){ Color="Rood", Name = "Harten 2" },
    new Card(){ Color="Rood", Name = "Harten 3" },
    new Card(){ Color="Rood", Name = "Harten 4" },
    new Card(){ Color="Rood", Name = "Harten 5" },
    new Card(){ Color="Rood", Name = "Harten 6" },
    new Card(){ Color="Rood", Name = "Harten 7" },
    new Card(){ Color="Rood", Name = "Harten 8" },
    new Card(){ Color="Rood", Name = "Harten 9" },
    new Card(){ Color="Rood", Name = "Harten 10" },
    new Card(){ Color="Rood", Name = "Harten boer" },
    new Card(){ Color="Rood", Name = "Harten dame" },
    new Card(){ Color="Rood", Name = "Harten heer" },
    new Card(){ Color="Rood", Name = "Ruiten 1" },
    new Card(){ Color="Rood", Name = "Ruiten 2" },
    new Card(){ Color="Rood", Name = "Ruiten 3" },
    new Card(){ Color="Rood", Name = "Ruiten 4" },
    new Card(){ Color="Rood", Name = "Ruiten 5" },
    new Card(){ Color="Rood", Name = "Ruiten 6" },
    new Card(){ Color="Rood", Name = "Ruiten 7" },
    new Card(){ Color="Rood", Name = "Ruiten 8" },
    new Card(){ Color="Rood", Name = "Ruiten 9" },
    new Card(){ Color="Rood", Name = "Ruiten 10" },
    new Card(){ Color="Rood", Name = "Ruiten boer" },
    new Card(){ Color="Rood", Name = "Ruiten dame" },
    new Card(){ Color="Rood", Name = "Ruiten heer" },
    new Card(){ Color="Zwart", Name = "Schuppen 1" },
    new Card(){ Color="Zwart", Name = "Schuppen 2" },
    new Card(){ Color="Zwart", Name = "Schuppen 3" },
    new Card(){ Color="Zwart", Name = "Schuppen 4" },
    new Card(){ Color="Zwart", Name = "Schuppen 5" },
    new Card(){ Color="Zwart", Name = "Schuppen 6" },
    new Card(){ Color="Zwart", Name = "Schuppen 7" },
    new Card(){ Color="Zwart", Name = "Schuppen 8" },
    new Card(){ Color="Zwart", Name = "Schuppen 9" },
    new Card(){ Color="Zwart", Name = "Schuppen 10" },
    new Card(){ Color="Zwart", Name = "Schuppen boer" },
    new Card(){ Color="Zwart", Name = "Schuppen dame" },
    new Card(){ Color="Zwart", Name = "Schuppen heer" },
    new Card(){ Color="Zwart", Name = "Klaveren 1" },
    new Card(){ Color="Zwart", Name = "Klaveren 2" },
    new Card(){ Color="Zwart", Name = "Klaveren 3" },
    new Card(){ Color="Zwart", Name = "Klaveren 4" },
    new Card(){ Color="Zwart", Name = "Klaveren 5" },
    new Card(){ Color="Zwart", Name = "Klaveren 6" },
    new Card(){ Color="Zwart", Name = "Klaveren 7" },
    new Card(){ Color="Zwart", Name = "Klaveren 8" },
    new Card(){ Color="Zwart", Name = "Klaveren 9" },
    new Card(){ Color="Zwart", Name = "Klaveren 10" },
    new Card(){ Color="Zwart", Name = "Klaveren boer" },
    new Card(){ Color="Zwart", Name = "Klaveren dame" },
    new Card(){ Color="Zwart", Name = "Klaveren heer" }
};

        static void Main(string[] args)
        {
            int credits = 1000;

            do
            {
                Console.WriteLine($"Huidige credits: {credits}");
                int stake = GetStake(credits);
                string chosenColor = GetCardChoice();
                credits = PullCard(chosenColor, credits, stake);

            } while (credits > 0);
        }

        private static int GetStake(int credits)
        {
            int stake;
            do
            {
                Console.Write("Uw inzet: ");
            } while (!int.TryParse(Console.ReadLine(), out stake) || stake < 0 || stake > credits);

            return stake;
        }

        private static string GetCardChoice()
        {
            string suit;

            do
            {
                string text = string.Join(",", _cardColors.Keys.ToList()); // string.Join vraagt welke lijst je wil en wat je er wil tussenzetten, in dit geval een komma
                Console.Write($"Kies een kleur {text}: ");
                suit = Console.ReadLine()!;
            } while (!_cardColors.ContainsKey(suit)); //zolang gebruiker iets ingeeft wat niet in de dictionary zit, moet hij opnieuw een kleur ingeven.
            //} while (!suit.Equals("H") && !suit.Equals("R") && !suit.Equals("S") && !suit.Equals("K"));

            //if(suit.Equals("H") || suit.Equals("R"))
            //{
            //    return "Rood";
            //}
            //else
            //{
            //    return "Zwart";
            //}

            string color = _cardColors[suit];
            return color;
        }

        static Random _rng = new Random();

        private static int PullCard(string cardChoice, int credits, int stake)
        {
            int randomIndex = _rng.Next(0, _cardDeck.Count);
            Card randomCard = _cardDeck[randomIndex];

            _cardDeck.RemoveAt(randomIndex);

            Console.WriteLine($"De getrokken kaart is {randomCard.Name} ({randomCard.Color})");

            if(randomCard.Color.Equals(cardChoice))
            {
                Console.WriteLine($"U hebt {stake * 2} gewonnen.");
                credits += stake * 2;
            }
            else
            {
                Console.WriteLine($"U hebt {stake} verloren.");
                credits -= stake;
            }

            return credits;
        }
    }
}
