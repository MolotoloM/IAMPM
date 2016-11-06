using IAMPM.GameObjects.Enums.CardProject;
using IAMPM.GameObjects.Models.ModelProject;
using IAMPM.GameObjects.Models.ModelTeam;

namespace IAMPM.Services.Interfaces
{
    //в интерфейсе все public
    public interface ICardFactory
    {
        CardTeamDeveloper[] GetDevAllCards();
        CardTeamManager[] GetManAllCards();
        CardTeamDeveloper[] CreateDevAllCards();
        CardTeamManager[] CreateManAllCards();
        CardProjectOutsource[] CreateProjectOutsourceCards();
    }
}