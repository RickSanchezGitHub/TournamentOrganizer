using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface ITeamPlayerRepository
    {
        void Delete(int teamid, int playerId);
        List<Team> GetTeamsByPlayerId(int playerId);
        int Insert(TeamPlayer teamPlayer);
    }
}