using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service.TeamPlayerService
{
    public interface ITeamPLayerService
    {
        void Insert(TeamPlayerModel teamPlayerModel);
        void Delete(TeamPlayerModel teamPlayerModel);

    }
}