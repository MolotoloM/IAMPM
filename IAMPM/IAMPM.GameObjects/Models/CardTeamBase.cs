using IAMPM.GameObjects.Enums;

namespace IAMPM.GameObjects.Models
{
    public abstract class CardTeamBase //к абстрактному классу нельзя создавать объекты
    {
        //создание id карты команды через свойство get и protected конструктор
        private static int _id = 1;

        protected CardTeamBase()
        {
            Id = _id++;
        }

        protected CardTeamBase(
            CardTeamType type,
            CardTeamTechnology technology,
            CardTeamLevel level,
            CardTeamDomain domain,
            CardTeamSalary salary,
            CardTeamSalaryBonus salaryBonus)
        {
            Type = type;
            Technology = technology;
            Level = level;
            Domain = domain;
            Salary = salary;
            SalaryBonus = salaryBonus;
        }

        public int Id { get; }

        public CardTeamType Type { get; private set; }
        public CardTeamTechnology Technology { get; private set; }
        public CardTeamLevel Level { get; private set; }
        public CardTeamDomain Domain { get; private set; }
        public CardTeamSalary Salary { get; private set; }
        public CardTeamSalaryBonus SalaryBonus { get; private set; }
    }
}