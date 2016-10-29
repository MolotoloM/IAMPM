using System;
using IAMPM.GameObjects.Enums;

namespace IAMPM.GameObjects.Models
{
    public class CardTeamManager : CardTeamBase
    {
        public CardTeamCapacity Capacity { get; private set; }
        public CardTeamSales Sales { get; private set; }
        public CardTeamManOccupation Occupation { get; private set; }

        public CardTeamManager(
            CardTeamType type,
            CardTeamTechnology technology,
            CardTeamLevel level,
            CardTeamManOccupation occupation)
            : base(type, technology, level)
        {
            Occupation = occupation;
            Capacity = GetTeamCapacityByLevel(level);
            Sales = GetTeamSalesByLevel(level);
        }

        private CardTeamCapacity GetTeamCapacityByLevel(CardTeamLevel level)
        {
            switch (level)
            {
                case CardTeamLevel.Intern:
                    return CardTeamCapacity.Intern;
                case CardTeamLevel.Junior:
                    return CardTeamCapacity.Junior;
                case CardTeamLevel.Middle:
                    return CardTeamCapacity.Middle;
                case CardTeamLevel.Senior:
                    return CardTeamCapacity.Senior;
                case CardTeamLevel.Chief:
                    return CardTeamCapacity.Chief;
                default:
                    throw new NotImplementedException();
            }
        }

        private CardTeamSales GetTeamSalesByLevel(CardTeamLevel level)
        {
            switch (level)
            {
                case CardTeamLevel.Intern:
                    return CardTeamSales.Intern;
                case CardTeamLevel.Junior:
                    return CardTeamSales.Junior;
                case CardTeamLevel.Middle:
                    return CardTeamSales.Middle;
                case CardTeamLevel.Senior:
                    return CardTeamSales.Senior;
                case CardTeamLevel.Chief:
                    return CardTeamSales.Chief;
                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Type: {1}, Technology: {2}, Level: {3}, Capacity: {4}, Sales: {5},  Occupation: {6}, Salary: {7}, Salary Bonus: {8}",
                Id, Type, Technology, Level, Capacity, Sales, Occupation, Salary, SalaryBonus);
        }
    }
}