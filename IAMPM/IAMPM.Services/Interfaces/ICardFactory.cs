using IAMPM.GameObjects.Enums;
using IAMPM.GameObjects.Models;

namespace IAMPM.Services.Interfaces
{
    //в интерфейсе все public
    public interface ICardFactory
    {
        CardTeamDeveloper[] GetDevAllCards();
        CardTeamManager[] GetManAllCards();
        CardTeamDeveloper[] CreateDevAllCards();
        CardTeamManager[] CreateManAllCards();
    }
}