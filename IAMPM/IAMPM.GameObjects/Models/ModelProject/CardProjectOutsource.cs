using IAMPM.GameObjects.Enums.CardProject;

namespace IAMPM.GameObjects.Models.ModelProject
{
    public class CardProjectOutsource : CardProjectBase
    {
        public int Budget { get; set; }
        public int? DeadlinePenalty { get; set; } //int? - это nullble

        public int DeadlinePenaltyValue
        {
            get
            {
                if (DeadlinePenalty.HasValue)
                {
                    return (int)(Budget * DeadlinePenalty.Value / 100);
                }
                return 0;
            }
        }

        public CardProjectOutsource(
            int budget,
            int? deadlinePenalty,
            CardProjectType type,
            int workload,
            int period,
            CardProjectDependency startDependency,
            CardProjectDependency finishDependency = null)
            : base(type, workload, period, startDependency, finishDependency)
        {
            Budget = budget;
            DeadlinePenalty = deadlinePenalty;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Type: {1}, Workload: {2}, Period: {3}, Budget: {4}, Start Dependency: {5}, Finish Dependency: {6}, Deadline Penalty: {7}",
                Id, Type, Workload, Period, Budget, StartDependency, FinishDependency, DeadlinePenalty);
        }
    }
}
