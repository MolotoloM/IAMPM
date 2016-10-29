using System.Collections.Generic;
using System.Configuration;
using System.IO;
using IAMPM.GameObjects.Enums;
using IAMPM.GameObjects.Models;
using IAMPM.Helpers;
using IAMPM.Services.Interfaces;

namespace IAMPM.Services.Implementations
{
    public class CardFactory : ICardFactory
    {
        private readonly string _devCardsJsonPath = ConfigurationManager.AppSettings["DevCardsJson"];
        private readonly string _manCardsJsonPath = ConfigurationManager.AppSettings["ManCardsJson"];

        public CardTeamDeveloper[] GetDevAllCards()
        {
            if (ValidateFile(_devCardsJsonPath))
            {
                var json = File.ReadAllText(_devCardsJsonPath);
                return json.Deserialize<CardTeamDeveloper[]>();
            }
            return null;
        }

        public CardTeamManager[] GetManAllCards()
        {
            if (ValidateFile(_manCardsJsonPath))
            {
                var json = File.ReadAllText(_manCardsJsonPath);
                return json.Deserialize<CardTeamManager[]>();
            }
            return null;
        }

        public CardTeamDeveloper[] CreateDevAllCards()
        {
            var testCards = new List<CardTeamDeveloper>();

            CardTeamTechnology[] technologyArray =
            {
                CardTeamTechnology.Web,
                CardTeamTechnology.Mobile,
                CardTeamTechnology.Desktop,
                CardTeamTechnology.IoT,
                CardTeamTechnology.BigData
            };

            CardTeamLevel[] levelArray =
            {
                CardTeamLevel.Intern,
                CardTeamLevel.Junior,
                CardTeamLevel.Middle,
                CardTeamLevel.Senior,
                CardTeamLevel.Chief
            };

            foreach (var technology in technologyArray)
            {
                for (var i = 0; i < 2; i++)
                {
                    foreach (var level in levelArray)
                    {
                        testCards.Add(new CardTeamDeveloper(CardTeamType.Developer, technology, level,
                            CardTeamDevOccupation.Developer));
                    }
                }
            }
            return testCards.ToArray();
        }

        public CardTeamManager[] CreateManAllCards()
        {
            var testCards = new List<CardTeamManager>();

            CardTeamTechnology[] technologyArray =
            {
                CardTeamTechnology.Web,
                CardTeamTechnology.Mobile,
                CardTeamTechnology.Desktop,
                CardTeamTechnology.IoT,
                CardTeamTechnology.BigData
            };

            CardTeamLevel[] levelArray =
            {
                CardTeamLevel.Intern,
                CardTeamLevel.Junior,
                CardTeamLevel.Middle,
                CardTeamLevel.Senior,
                CardTeamLevel.Chief
            };

            foreach (var technology in technologyArray)
            {
                for (var i = 0; i < 2; i++)
                {
                    foreach (var level in levelArray)
                    {
                        testCards.Add(new CardTeamManager(CardTeamType.Manager, technology, level,
                            CardTeamManOccupation.HR));
                    }
                }
            }
            return testCards.ToArray();
        }

        private bool ValidateFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            if (File.Exists(path) == false)
            {
                return false;
            }
            return true;
        }
    }
}