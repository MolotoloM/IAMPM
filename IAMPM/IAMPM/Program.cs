using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using IAMPM.GameObjects.Enums;
using IAMPM.GameObjects.Models;
using IAMPM.GameObjects.Models.ModelTeam;
using IAMPM.Helpers;
using IAMPM.Services.Implementations;

namespace IAMPM
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateProjectCards();
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
            File.WriteAllText("ProjectCards.js", json);
        }
    }
}
