using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface IResultTournamentPlayerRepository
    {
        int AddPlayerToTournament(Player player, int tournamentId);
        void DeleteByTournament(int id, int tournamentId);
        List<ResultTournamentPlayer> GetPlayerResultsInAllTournaments(int playerId);
        List<ResultTournamentPlayer> GetPlayerResultsInTournament(int playerId, int tournamentId);
        List<Player> GetPlayersInTournamentsByTournamentId(int tournamentId);
        List<ResultTournamentPlayer> GetPlayersResultsInTournamentRound(int tournamentId, int numberRound);
        void Insert(ResultTournamentPlayer resultTournamentPlayer);
        void SetPlayerResultInRoundOfTournament(int newResult, ResultTournamentPlayer resultTournamentPlayer);
    }
}