using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public interface IResultTournamentTeamService
    {
        void DeleteByTeamIdAndTournamentId(int teamId, int tournamentId);
        void DeleteByTournamentRound(int tournamentId, int numberRound);
        List<ResultTournamentTeamModel> GetDataOfTournament(int tournamentId);
        List<ResultTournamentTeamModel> GetDataOfTournamentByRound(int tournamentId, int numberRound);
        List<ResultTournamentTeamModel> GetTeamResultsInTournament(int teamId, int tournamentId);
        int InsertTeamIdRoundMatchTournament(ResultTournamentTeamModel resultTournamentTeamModel);
        void SetTeamResultInRoundOfTournament(ResultTournamentTeamModel resultTournamentTeamModel, int newResult);
        List<TeamModel> GetTeamsByTournamentId(int tournamentId);
    }
}