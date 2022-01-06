using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface IPlayerRepository
    {
        void Delete(int id);
        List<Player> GetAll();
        Player GetById(int id);
        List<Player> GetPlayersInTournament(int tournamentId);
        int Insert(Player player);
        void Update(int id, Player player);
    }
}