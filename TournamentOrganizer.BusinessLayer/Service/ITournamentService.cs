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
        public List<PlayerModel> GetPlayersInTournament(int tournamentId);
        public void DeletePlayerFromTournament(int playerId, int tournamentId);
        public int AddPalyerToTournament(PlayerModel player, int tournamentId);
        public List<PlayerModel> GetAllPlayers();
        public List<TeamModel> GetAllTeams();
        public List<TeamModel> GetTeamsInTournament(int tournamentId);
        public int AddTeamToTournament(TeamModel team, int tournamentId);
    }
}