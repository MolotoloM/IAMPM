using System.CodeDom;
using IAMPM.GameObjects.Enums.CardProject;

namespace IAMPM.GameObjects.Models.ModelProject
{
    public abstract class CardProjectBase
    {
        private static int _id = 1;

        public int Id { get; }

        public CardProjectType Type { get; set; }
        public int Workload { get; set; }
        public int Period { get; set; }

        public CardProjectDependency StartDependency { get; set; }
        public CardProjectDependency FinishDependency { get; set; }

        protected CardProjectBase (
            CardProjectType type,
            int workload,
            int period,
            CardProjectDependency startDependency,
            CardProjectDependency finishDependency)
        {
            Id = _id++;
            Type = type;
            Workload = workload;
            Period = period;
            StartDependency = startDependency;
            FinishDependency = finishDependency;
        }
    }
}
