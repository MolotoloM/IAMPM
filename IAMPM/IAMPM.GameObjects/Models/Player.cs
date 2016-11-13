using System.Collections.Generic;
using IAMPM.GameObjects.Models.ModelTeam;

namespace IAMPM.GameObjects.Models
{
    public class Player
    {
        private const int MinTeamCardCount = 2;
        private const int MaxTeamCardCount = 10;

        public List<CardTeamDeveloper> TeamDevPlayer { get; set; }
        public List<CardTeamManager> TeamManPlayer { get; set; }

        public Player(List<CardTeamDeveloper> teamDevPlayer, List<CardTeamManager> teamManPlayer)
        {
            TeamDevPlayer = teamDevPlayer;
            TeamManPlayer = teamManPlayer;
        }
    }
}