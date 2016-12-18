using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using IAMPM.GameEngine.Interfaces;
using IAMPM.GameObjects.Enums.CardProject;
using IAMPM.GameObjects.Enums.CardTeam;
using IAMPM.GameObjects.Exceptions;
using IAMPM.GameObjects.Models;
using IAMPM.GameObjects.Models.ModelProject;
using IAMPM.GameObjects.Models.ModelTeam;
using IAMPM.Helpers;
using IAMPM.Services.Interfaces;

namespace IAMPM.GameEngine.Implementations
{
    public class IampmGame : IGame
    {
        private readonly ICardFactory _cardFactory;
        private readonly List<Player> _players;
        private readonly int _playersCount;
        private readonly List<CardTeamDeveloper> _devCards;
        private readonly List<CardTeamManager> _manCards;
        private readonly List<CardProjectBase> _projectCards; 

        public IampmGame(ICardFactory cardFactory, int playersCount)
        {
            _cardFactory = cardFactory;
            _playersCount = playersCount;

            _devCards = _cardFactory.GetDevAllCards().ToList();
            _manCards = _cardFactory.GetManAllCards().ToList();
            _projectCards = _cardFactory.GetProjectAllCards().ToList();

            _players = new List<Player>();
        }

        #region IGame
        public void PreStart()
        {
            CreatePlayers();
        }

        public void InProgress()
        {

        }
        #endregion

        private void CreatePlayers()
        {
            for (int i = 0; i < _playersCount; i++)
            {
                List<CardTeamDeveloper> devsInHand = GetDevCardsForPlayer();
                List<CardTeamManager> mansInHand = GetManCardsForPlayer();
                _players.Add(new Player(devsInHand, mansInHand, null));
            }
        }

        private List<CardTeamDeveloper> GetDevCardsForPlayer()
        {
            CardTeamDeveloper devCard;
            var devsinHand = new List<CardTeamDeveloper>();
            for (int j = 0; j < 3; j++)
            {
                devCard = GetRandomTeamCard(_devCards, CardTeamLevel.Intern);
                devsinHand.Add(devCard);
                _devCards.Remove(devCard);
            }

            devCard = GetRandomTeamCard(_devCards, CardTeamLevel.Junior);
            devsinHand.Add(devCard);
            _devCards.Remove(devCard);

            return devsinHand;
        }

        private List<CardTeamManager> GetManCardsForPlayer()
        {
            var mansInHand = new List<CardTeamManager>();
            var manCard = GetRandomTeamCard(_manCards, CardTeamLevel.Middle);

            mansInHand.Add(manCard);
            _manCards.Remove(manCard);

            return mansInHand;
        }

        private T GetRandomTeamCard<T>(IEnumerable<T> cards, CardTeamLevel level) where T : CardTeamBase
        {
            T[] filteredCards = cards.Where(c => c.Level == level).ToArray();
            return filteredCards.GetRandom($"TeamCard with level {level} not found"); // $ is string.format from C# 6 version
        }

        private T GetRandomStartProjectCard<T>(IEnumerable<T> cards, CardProjectType type, int maxWorkload, int maxPeriod) where T: CardProjectBase
        {
            T[] filteredCards = cards
                .Where(c => c.Type == type && c.Workload <= maxWorkload && c.Period <= maxPeriod)
                .ToArray();
            return filteredCards.GetRandom("StartProjectCard not found");
        }
    }
}
