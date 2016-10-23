using IAMPM.GameObjects.Enums;

namespace IAMPM.GameObjects.Models
{
    public class CardTeamDeveloper : CardTeamBase
    {
        public CardTeamVelocity Velocity { get; private set; }
        public CardTeamDevOccupation Occupation { get; private set; }

        public CardTeamDeveloper(CardTeamType type, CardTeamTechnology technology, CardTeamLevel level, CardTeamDomain domain, CardTeamSalary salary, CardTeamSalaryBonus salaryBonus, CardTeamVelocity velocity, CardTeamDevOccupation occupation) : base(type, technology, level, domain, salary, salaryBonus)
        {
            Velocity = velocity;
            Occupation = occupation;
        }
    }
}
