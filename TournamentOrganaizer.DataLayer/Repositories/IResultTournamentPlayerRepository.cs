using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface IResultTournamentPlayerRepository
    {
        void AddPlayerToTournament(Player player, int tournamentId);
        void DeleteByPlayerIdAndTournamentId(int playerId, int tournamentId);
        void DeleteByTournamentRound(int tournamentId, int numberRound);
        List<ResultTournamentPlayer> GetDataOfTournament(int tournamentId);
        List<ResultTournamentPlayer> GetPlayerResultsInTournament(int playerId, int tournamentId);
        List<ResultTournamentPlayer> GetPlayersResultsInTournamentRound(int tournamentId, int numberRound);
        int InsertPlayerIdRoundMatchTournament(ResultTournamentPlayer resultTournamentPlayer);
        void SetPlayerResultInRoundOfTournament(int newResult, ResultTournamentPlayer resultTournamentPlayer);
    }
}