using IAMPM.GameObjects.Enums.CardProject;

namespace IAMPM.GameObjects.Models.ModelProject
{
    public class CardProjectDependencyItem<T>
    {
        public TeamDependency People { get; set; }
        public T Value { get; set; }
    }
}