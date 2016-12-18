using IAMPM.GameObjects.Enums.CardProject;
using IAMPM.GameObjects.Models.ModelProject;
using IAMPM.GameObjects.Models.ModelTeam;

namespace IAMPM.Services.Interfaces
{
    //в интерфейсе все public
    public interface ICardFactory
    {
        #region GET
        CardTeamDeveloper[] GetDevAllCards();
        CardTeamManager[] GetManAllCards();
        CardProjectBase[] GetProjectAllCards();
        CardProjectOutsource[] GetProjectOutsourceAllCards();
        CardProjectProduct[] GetProjectProductAllCards();
        #endregion

        #region Create
        CardTeamDeveloper[] CreateDevAllCards();
        CardTeamManager[] CreateManAllCards();
        CardProjectOutsource[] CreateProjectOutsourceCards(); 
        #endregion
    }
}