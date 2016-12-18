using IAMPM.GameObjects.Enums.CardProject;

namespace IAMPM.GameObjects.Models.ModelProject
{
    public class CardProjectProduct : CardProjectBase
    {
        public CardProjectProduct(
            CardProjectType type,
            int workload,
            int period,
            CardProjectDependency startDependency,
            CardProjectDependency finishDependency
            ) : base(type, workload, period, startDependency, finishDependency)
        {
        }
    }
}