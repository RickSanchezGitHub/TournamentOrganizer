using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface ITeamRepository
    {
        void Delete(int id);
        List<Team> GetAll();
        List<Player> GetAvailablePlayersToAdd(int id);
        Team GetById(int id);
        int Insert(Team team);
        void Update(int id, Team team);
    }
}