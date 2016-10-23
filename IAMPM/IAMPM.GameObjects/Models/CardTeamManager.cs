using IAMPM.GameObjects.Enums;

namespace IAMPM.GameObjects.Models
{
    public class CardTeamManager : CardTeamBase
    {
        public CardTeamCapacity Capacity { get; private set; }
        public CardTeamSales Sales { get; private set; }
        public CardTeamManOccupation Occupation { get; private set; }

        public CardTeamManager(CardTeamType type, CardTeamTechnology technology, CardTeamLevel level, CardTeamDomain domain, CardTeamSalary salary, CardTeamSalaryBonus salaryBonus, CardTeamCapacity capacity, CardTeamSales sales, CardTeamManOccupation occupation) : base(type, technology, level, domain, salary, salaryBonus)
        {
            Capacity = capacity;
            Sales = sales;
            Occupation = occupation;
        }
    }
}