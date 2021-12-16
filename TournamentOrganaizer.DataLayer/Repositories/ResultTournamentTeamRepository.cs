using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.DataLayer.Entities;
using Dapper;
using TournamentOrganaizer.DataLayer.Entities;
using System.Data.SqlClient;
using System.Data;
using TournamentOrganaizer.DataLayer.Repositories;

namespace TournamentOrganizer.DataLayer.Repositories
{
    class ResultTournamentTeamRepository: BaseRepository
    { 
        public void Insert(ResultTournamentTeam resultTournamentTeam)
        {
            string storedProcedure = "[dbo].[ResultTournamentTeam_Insert]";
            using IDbConnection sqlConnection = ProvideConnection();

            var newRows = sqlConnection.Execute(storedProcedure,
                new
                {
                    TeamId = resultTournamentTeam.Team.Id,
                    Result = resultTournamentTeam.Result,
                    NumberRound = resultTournamentTeam.NumberRound,
                    NumberMatch = resultTournamentTeam.NumberMatch,
                    TournamentId = resultTournamentTeam.Tournament.Id
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournament(int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_DeleteByTournamentId]";
            sqlConnection.Execute
                (
                    storedProcedure,
                    new { TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void SetPlayerResultInRoundOfTournament(ResultTournamentTeam resultTournamentTeam, int newResult)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure ="[dbo].[ResultTournamentTeam_SetTeamResultInRoundOfTournament]";
            var newRows = sqlConnection.Execute(
                    storedProcedure,
                    new
                    {
                        TeamId = resultTournamentTeam.Team.Id,
                        newResult = newResult,
                        NumberRound = resultTournamentTeam.NumberRound,
                        TournamentId = resultTournamentTeam.Tournament.Id
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public List<ResultTournamentTeam> GetTeamsResultsInTournament(int teamId, int tournamentId)
        {

            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "dbo.ResultTournamentTeam_SelectByTeamIdAndTournamentId";
            var result = sqlConnection.Query<ResultTournamentTeam, Team, ResultTournamentTeam>
                (
                    storedProcedure,
                    (resultTournamentTeam, team) =>
                    {
                        resultTournamentTeam.Team = team;
                        return resultTournamentTeam;
                    },
                    new { TeamId = teamId, TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                )
                .ToList();

            return result;
        }

        public List<Team> GetTeamsInTournament(int tournamentId)
        {

            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_SelectByTournamentId]";
            var teamDictionary = new Dictionary<int, Team>();

            var result = sqlConnection.Query<Team, ResultTournamentTeam, Team>
                (
                    storedProcedure,
                    (team, ResultTournamentTeam) =>
                    {
                        if (!teamDictionary.TryGetValue(team.Id, out var teamEntry))
                        {
                            teamEntry = team;
                            teamDictionary.Add(teamEntry.Id, teamEntry);
                        }
                        return teamEntry;
                    },
                    new { TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                )
                .Distinct()
                .ToList();

            return result;
        }

        public List<ResultTournamentTeam> GetPlayerResultsInAllTournaments(int teamId)
        {

            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "dbo.ResultTournamentTeam_SelectByTeamId";
            var result = sqlConnection.Query<ResultTournamentTeam, Tournament, ResultTournamentTeam>
                (
                    storedProcedure,
                    (resultTournamentTeam, tournament) =>
                    {
                        resultTournamentTeam.Tournament = tournament;
                        return resultTournamentTeam;
                    },
                    new { TeamId = teamId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                )
                .ToList();

            return result;
        }

    }
}
