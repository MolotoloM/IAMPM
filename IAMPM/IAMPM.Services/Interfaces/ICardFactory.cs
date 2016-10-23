using IAMPM.GameObjects.Models;

namespace IAMPM.Services.Interfaces
{
    //в интерфейсе все public
    public interface ICardFactory
    {
        CardTeamBase[] GetDevAllCards();
    }
}