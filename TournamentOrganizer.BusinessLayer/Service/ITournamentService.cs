using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public interface ITournamentService
    {
        void DeleteTournament(int id);
        List<GameModel> GetAllGames();
        List<TournamentModel> GetAllTournaments();
        int InsertTournament(TournamentModel tournament);
        void UpdateTournament(TournamentModel tournament);
    }
}