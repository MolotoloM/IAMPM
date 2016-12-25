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
        private readonly IConfigurationService _configurationService;

        private readonly List<Player> _players;
        private int _playersCount;
        private List<CardTeamDeveloper> _devCards;
        private List<CardTeamManager> _manCards;
        private List<CardProjectBase> _projectCards;


        public IampmGame(ICardFactory cardFactory, IConfigurationService configurationService, int playersCount)
        {
            _cardFactory = cardFactory;
            _configurationService = configurationService;

            _playersCount = playersCount;

            _players = new List<Player>();
        }

        #region IGame
        public void PreStart()
        {
            Validate();

            _devCards = _cardFactory.GetDevAllCards().ToList();
            _manCards = _cardFactory.GetManAllCards().ToList();
            _projectCards = _cardFactory.GetProjectAllCards().ToList();

            CreatePlayers();
        }


        public void InProgress()
        {

        }
        #endregion

        private void Validate()
        {
            if (_playersCount < _configurationService.MinPlayersCount ||
                _playersCount > _configurationService.MaxPlayersCount)
            {
                throw new InvalidParamExeption<int>(nameof(_playersCount), _playersCount, _configurationService.MinPlayersCount, _configurationService.MaxPlayersCount);
            }
        }

        private void CreatePlayers()
        {
            CardProjectBase startProject = GetRandomStartProjectCard(CardProjectType.Outsource, _configurationService.DefStartProjectWorkload, _configurationService.DefStartProjectPeriod);

            for (int i = 0; i < _playersCount; i++)
            {
                List<CardTeamDeveloper> devsInHand = GetStartDevCardsForPlayer();
                List<CardTeamManager> mansInHand = GetStartManCardsForPlayer();
                _players.Add(new Player(devsInHand, mansInHand, startProject));
            }
        }

        private List<CardTeamDeveloper> GetStartDevCardsForPlayer()
        {
            CardTeamDeveloper devCard;
            var devsinHand = new List<CardTeamDeveloper>();
            for (int j = 0; j < _configurationService.DefStartDevCardsCount; j++)
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

        private List<CardTeamManager> GetStartManCardsForPlayer()
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

        private CardProjectBase GetRandomStartProjectCard(CardProjectType type, int maxWorkload, int maxPeriod)
        {
            CardProjectBase[] filteredCards = _projectCards
                .Where(c => c.Type == type && c.Workload <= maxWorkload && c.Period <= maxPeriod)
                .ToArray();

            var card = filteredCards.GetRandom("StartProjectCard not found");
            card.IsStart = true;

            _projectCards.Remove(card);
            return card;
        }
    }
}
