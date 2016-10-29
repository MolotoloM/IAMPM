using System;
using System.Runtime.InteropServices;
using IAMPM.GameObjects.Enums;

namespace IAMPM.GameObjects.Models
{
    public class CardTeamDeveloper : CardTeamBase
    {
        public CardTeamVelocity Velocity { get; private set; }
        public CardTeamDevOccupation Occupation { get; private set; }

        public CardTeamDeveloper(
            CardTeamType type,
            CardTeamTechnology technology,
            CardTeamLevel level,
            CardTeamDevOccupation occupation)
            : base(type, technology, level)
        {
            Occupation = occupation;
            Velocity = GetTeamVelosityByLevel(level);
        }

        private CardTeamVelocity GetTeamVelosityByLevel(CardTeamLevel level)
        {
            switch (level)
            {
                case CardTeamLevel.Intern:
                    return CardTeamVelocity.Intern;
                case CardTeamLevel.Junior:
                    return CardTeamVelocity.Junior;
                case CardTeamLevel.Middle:
                    return CardTeamVelocity.Middle;
                case CardTeamLevel.Senior:
                    return CardTeamVelocity.Senior;
                case CardTeamLevel.Chief:
                    return CardTeamVelocity.Chief;
                default: throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Type: {1}, Technology: {2}, Level: {3}, Velocity: {4}, Occupation: {5}, Salary: {6}, Salary Bonus: {7}", 
                Id, Type, Technology, Level, Velocity, Occupation, Salary, SalaryBonus);
        }
    }
}
