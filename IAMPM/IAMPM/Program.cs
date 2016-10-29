using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using IAMPM.GameObjects.Enums;
using IAMPM.GameObjects.Models;
using IAMPM.Helpers;
using IAMPM.Services.Implementations;

namespace IAMPM
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new CardFactory();
            //CardTeamBase[] cards = factory.GetDevAllCards();

            //CardTeamDeveloper[] devCards1 = factory.CreateDevAllCards();
            //CardTeamManager[] manCards1 = factory.CreateManAllCards();
            //
            //string jsonDevCards = devCards1.Serialize();
            //string jsonManCards = manCards1.Serialize();
            //
            //File.WriteAllText(@"F:\Dropbox\ProJecT\IAMPM\BoardGame\2.0\beta\IAMPM\IAMPM\Data\DevCards.json", jsonDevCards);
            //File.WriteAllText(@"F:\Dropbox\ProJecT\IAMPM\BoardGame\2.0\beta\IAMPM\IAMPM\Data\ManCards.json", jsonManCards);

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

    }
    
}
