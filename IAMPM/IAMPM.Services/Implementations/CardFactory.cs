using System.Configuration;
using System.IO;
using IAMPM.GameObjects.Models;
using IAMPM.Helpers;
using IAMPM.Services.Interfaces;

namespace IAMPM.Services.Implementations
{
    public class CardFactory : ICardFactory
    {
        private readonly string _allCardsJsonPath = ConfigurationManager.AppSettings["AllCardsJson"];

        public CardTeamBase[] GetDevAllCards()
        {
            if (string.IsNullOrEmpty(_allCardsJsonPath))
            {
                return null;
            }
            if (File.Exists(_allCardsJsonPath) == false)
            {
                return null;
            }
            string json = File.ReadAllText(_allCardsJsonPath);
            return json.Deserialize<CardTeamDeveloper[]>();
        }
    }
}