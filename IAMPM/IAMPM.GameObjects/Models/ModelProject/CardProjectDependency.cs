using IAMPM.GameObjects.Enums.CardTeam;

namespace IAMPM.GameObjects.Models.ModelProject
{
    public class CardProjectDependency
    {
        public CardProjectDependencyItem<CardTeamLevel>[] Level { get; set; }
        public CardProjectDependencyItem<CardTeamDomain>[] Domain { get; set; }
        public CardProjectDependencyItem<CardTeamTechnology>[] Technology { get; set; }
        public CardProjectDependencyItem<CardTeamDevOccupation>[] Occupation { get; set; }
    }
}
