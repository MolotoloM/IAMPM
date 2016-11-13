using System;
using System.IO;
using IAMPM.GameEngine.Implementations;
using IAMPM.GameEngine.Interfaces;
using IAMPM.GameObjects.Models.ModelTeam;
using IAMPM.Helpers;
using IAMPM.Services.Implementations;

namespace IAMPM
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateProjectCards();
            //GetProjectOutsourceAllCards();
            IGame game = new IampmGame(new CardFactory(), 1);
            IGameEngine gameEngine = new GameEngine.Implementations.GameEngine(game);
            gameEngine.Start();
        }

        static void GetProjectOutsourceAllCards()
        {
            var factory = new CardFactory();
            var cards = factory.GetProjectOutsourceAllCards();

            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
        }

        static void CreateTeamCards()
        {
            var factory = new CardFactory();

            CardTeamDeveloper[] devCards = factory.GetDevAllCards();
            CardTeamManager[] manCards = factory.GetManAllCards();

            Console.WriteLine("Developers:");
            foreach (var cardTeamDeveloper in devCards)
            {
                Console.WriteLine(cardTeamDeveloper);
            }
            Console.WriteLine("\nManagers:");
            foreach (var cardTeamManager in manCards)
            {
                Console.WriteLine(cardTeamManager);
            }
        }

        static void CreateProjectCards()
        {
            var factory = new CardFactory();
            var cards = factory.CreateProjectOutsourceCards();

            var json = cards.Serialize();
            File.WriteAllText("ProjectCards.json", json);
        }
    }
}
