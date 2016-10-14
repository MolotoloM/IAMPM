namespace IAMPM.GameObjects.Models
{
    public abstract class CardTeamBase //к абстрактному классу нельзя создавать объекты
    {
        //создание id карты команды через свойство get и protected конструктор
        private static int _id = 1;
        public int Id { get; }

        protected CardTeamBase()
        {
            Id = _id++;
        }
    }
}
