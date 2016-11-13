using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using IAMPM.GameEngine.Interfaces;
using IAMPM.GameObjects.Enums.CardTeam;
using IAMPM.GameObjects.Exceptions;
using IAMPM.GameObjects.Models;
using IAMPM.GameObjects.Models.ModelTeam;
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

        public IampmGame(ICardFactory cardFactory, int playersCount)
        {
            _cardFactory = cardFactory;
            _playersCount = playersCount;

            _devCards = _cardFactory.GetDevAllCards().ToList();
            _manCards = _cardFactory.GetManAllCards().ToList();
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
                List<CardTeamDeveloper> devsinHand = GetDevCardsForPlayer();
                _players.Add(new Player(devsinHand, null));
            }
        }

        private List<CardTeamDeveloper> GetDevCardsForPlayer()
        {
            CardTeamDeveloper devCard;
            var devsinHand = new List<CardTeamDeveloper>();
            for (int j = 0; j < 3; j++)
            {
                devCard = GetRandomCard(_devCards, CardTeamLevel.Intern);
                devsinHand.Add(devCard);
                _devCards.Remove(devCard);
            }

            devCard = GetRandomCard(_devCards, CardTeamLevel.Junior);
            devsinHand.Add(devCard);
            _devCards.Remove(devCard);

            return devsinHand;
        } 

        private T GetRandomCard<T>(IEnumerable<T> cards, CardTeamLevel level) where T : CardTeamBase
        {
            T[] filteredCards = cards.Where(c => c.Level == level).ToArray();
            if (filteredCards.Length == 0)
            {
                throw new CardCollectionException($"Card with level {level} not found"); // $ is string.format from C# 6 version
            }

            int randNumber = new Random().Next(filteredCards.Length - 1);
            T chosenCard = filteredCards[randNumber];
            return chosenCard;
        }
    }
}
