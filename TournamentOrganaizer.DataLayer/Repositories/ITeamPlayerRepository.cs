using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface ITeamPlayerRepository
    {
        void Delete(TeamPlayer teamPlayer);
        int Insert(TeamPlayer teamPlayer);
    }
}