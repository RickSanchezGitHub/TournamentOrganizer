using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public interface IResultTournamentTeamRepository
    {
        void DeleteByTournament(int tournamentId, int teamId);
        List<ResultTournamentTeam> GetPlayerResultsInAllTournaments(int teamId);
        List<Team> GetTeamsInTournament(int tournamentId);
        List<ResultTournamentTeam> GetTeamsResultsInTournament(int teamId, int tournamentId);
        void Insert(ResultTournamentTeam resultTournamentTeam);
        void SetPlayerResultInRoundOfTournament(ResultTournamentTeam resultTournamentTeam, int newResult);
        public int AddTeamToTournament(Team team, int tournamentId);

    }
}