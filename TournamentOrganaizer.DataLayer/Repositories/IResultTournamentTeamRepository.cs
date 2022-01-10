using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface IResultTournamentTeamRepository
    {
        void DeleteByTeamIdAndTournamentId(int teamId, int tournamentId);
        void DeleteByTournamentRound(int tournamentId, int numberRound);
        List<ResultTournamentTeam> GetDataOfTournament(int tournamentId);
        List<Team> GetTeamsInTournament(int tournamentId);
        List<ResultTournamentTeam> GetTeamsResultsInTournament(int teamId, int tournamentId);
        List<ResultTournamentTeam> GetTeamsResultsInTournamentRound(int tournamentId, int numberRound);
        int InsertTeamIdRoundMatchTournament(ResultTournamentTeam resultTournamentTeam);
        void SetTeamResultInRoundOfTournament(ResultTournamentTeam resultTournamentTeam, int newResult);
    }
}