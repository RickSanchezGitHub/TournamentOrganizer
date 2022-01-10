using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public interface IResultTournamentPlayerService
    {
        void DeleteByPlayerIdAndTournamentId(int playerId, int tournamentId);
        void DeleteByTournamentRound(int tournamentId, int numberRound);
        List<ResultTournamentPlayerModel> GetDataOfTournament(TournamentModel tournament);
        List<ResultTournamentPlayerModel> GetDataOfTournamentByRound(int tournamentId, int numberRound);
        List<ResultTournamentPlayerModel> GetPlayerResultsInTournament(int playerId, int tournamentId);
        int InsertPlayerIdRoundMatchTournament(ResultTournamentPlayerModel resultTournamentPlayerModel);
        void SetPlayerResultInRoundOfTournament(int newResult, ResultTournamentPlayerModel resultTournamentPlayerModel);
        List<PlayerModel> GetPlayersByTournamentId(TournamentModel tournament);
    }
}