using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
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
            CardTeamBase[] cards = factory.GetDevAllCards();

            var testCards = new List<CardTeamBase>();

            var types = new CardTeamType[]
            {
                //CardTeamType.Developer,
                CardTeamType.Manager
            };
            var technologies = new CardTeamTechnology[]
            {
                CardTeamTechnology.BigData,
                CardTeamTechnology.Desktop,
                CardTeamTechnology.IoT,
                CardTeamTechnology.Mobile,
                CardTeamTechnology.Web,
            };
            var levels = new CardTeamLevel[]
            {
                CardTeamLevel.Chief,
                CardTeamLevel.Intern,
                CardTeamLevel.Junior,
                CardTeamLevel.Middle,
                CardTeamLevel.Senior,
            };
            //var occupations = new CardTeamDevOccupation[]
            //{
            //    CardTeamDevOccupation.Analyst, CardTeamDevOccupation.Architect, CardTeamDevOccupation.Designer,
            //    CardTeamDevOccupation.Developer, CardTeamDevOccupation.QA,
            //};

            foreach (var type in types)
            {
                foreach (var technology in technologies)
                {
                    foreach (var level in levels)
                    {
                        testCards.Add(new CardTeamDeveloper(type, technology, level, CardTeamDevOccupation.Analyst));
                    }
                }
            }

            testCards.AddRange(testCards);
            string json = testCards.Serialize();
            File.WriteAllText("ManCards.json", json);
        }
    }
}
