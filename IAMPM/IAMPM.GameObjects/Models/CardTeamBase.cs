using System;
using IAMPM.GameObjects.Enums;

namespace IAMPM.GameObjects.Models
{
    public abstract class CardTeamBase //к абстрактному классу нельзя создавать объекты
    {
        //создание id карты команды через свойство get и protected конструктор
        private static int _id = 1;

        protected CardTeamBase()
        {

        }

        protected CardTeamBase(
            CardTeamType type,
            CardTeamTechnology technology,
            CardTeamLevel level
            )
        {
            Id = _id++;

            Type = type;
            Technology = technology;
            Level = level;
            Salary = GetSalaryByLevel(level);
            SalaryBonus = GetSalaryBonusByLevel(level);
        }

        public int Id { get; }

        public CardTeamType Type { get; private set; }
        public CardTeamTechnology Technology { get; private set; }
        public CardTeamLevel Level { get; private set; }
        public CardTeamDomain? Domain { get; private set; } //задание nulluble свойства
        public CardTeamSalary Salary { get; private set; }
        public CardTeamSalaryBonus SalaryBonus { get; private set; }

        private CardTeamSalary GetSalaryByLevel(CardTeamLevel level)
        {
            switch (level)
            {
                case CardTeamLevel.Intern:
                    return CardTeamSalary.Intern;
                case CardTeamLevel.Junior:
                    return CardTeamSalary.Junior;
                case CardTeamLevel.Middle:
                    return CardTeamSalary.Middle;
                case CardTeamLevel.Senior:
                    return CardTeamSalary.Senior;
                case CardTeamLevel.Chief:
                    return CardTeamSalary.Chief;
                default: throw new NotImplementedException();
            }
        }

        private CardTeamSalaryBonus GetSalaryBonusByLevel(CardTeamLevel level)
        {
            switch (level)
            {
                case CardTeamLevel.Intern:
                    return CardTeamSalaryBonus.Intern;
                case CardTeamLevel.Junior:
                    return CardTeamSalaryBonus.Junior;
                case CardTeamLevel.Middle:
                    return CardTeamSalaryBonus.Middle;
                case CardTeamLevel.Senior:
                    return CardTeamSalaryBonus.Senior;
                case CardTeamLevel.Chief:
                    return CardTeamSalaryBonus.Chief;
                default: throw new NotImplementedException();
            }
        }

    }
}