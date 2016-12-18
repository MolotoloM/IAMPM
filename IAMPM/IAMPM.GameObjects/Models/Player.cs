using System.Collections.Generic;
using IAMPM.GameObjects.Models.ModelProject;
using IAMPM.GameObjects.Models.ModelTeam;

namespace IAMPM.GameObjects.Models
{
    public class Player
    {
        private const int MinTeamCardCount = 2;
        private const int MaxTeamCardCount = 10;

        private readonly List<CardTeamDeveloper> _teamDevPlayer;
        private readonly List<CardTeamManager> _teamManPlayer;
        private readonly CardProjectBase _startProject;

        public Player(
            List<CardTeamDeveloper> teamDevPlayer, 
            List<CardTeamManager> teamManPlayer, 
            CardProjectBase startProject
            )
        {
            _teamDevPlayer = teamDevPlayer;
            _teamManPlayer = teamManPlayer;
            _startProject = startProject;
        }
    }
}