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
    public class ResultTournamentTeamRepository
    {
        

        string ConnectionString = RepositoryHelpers.ConnectionString;
       
        public void Insert(int teamId, int result, int round, int match, int tournamentId)
        {
            string storedProcedure = "[dbo].[ResultTournamentTeam_Insert]";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var newRows = sqlConnection.Execute(storedProcedure,
                new
                {
                    TeamId = teamId,
                    Result = result,
                    NumberRound = round,
                    NumberMatch = match,
                    TournamentId = tournamentId
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournament(int tournamentId)
        {
            string storedProcedure = "[dbo].[ResultTournamentTeam_DeleteByTournamentId]";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            sqlConnection.Execute(
                storedProcedure,
                new { TournamentId = tournamentId },
                commandType: CommandType.StoredProcedure
                );
        }

        public void SetPlayerResultInRoundOfTournament(int teamId, int newResult, int round, int tournamentId)
        {
            string storedProcedure = "[dbo].[ResultTournamentTeam_SetTeamResultInRoundOfTournament]";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var newRows = sqlConnection.Execute(
                storedProcedure,
                new
                {
                    TeamId = teamId,
                    newResult = newResult,
                    NumberRound = round,
                    TournamentId = tournamentId
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public List<ResultTournamentTeam> GetTeamsResultsInTournament(int teamId, int tournamentId)
        {
            string storedProcedure = "dbo.ResultTournamentTeam_SelectByTeamIdAndTournamentId";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var result = sqlConnection.Query<ResultTournamentTeam, Team, ResultTournamentTeam>(
               storedProcedure, 
                (resultTournamentTeam, team) =>
                {
                    resultTournamentTeam.Team = team;
                    return resultTournamentTeam;
                },
                new { TeamId = teamId, TournamentId = tournamentId },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();

            return result;
        }

        public List<Team> GetTeamsInTournament(int tournamentId)
        {
            string storedProcedure = "[dbo].[ResultTournamentTeam_SelectByTournamentId]";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var teamDictionary = new Dictionary<int, Team>();

            var result = sqlConnection.Query<Team, ResultTournamentTeam, Team>(
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
                ).Distinct()
                .ToList();

            return result;
        }

        public List<ResultTournamentTeam> GetPlayerResultsInAllTournaments(int teamId)
        {
            string storedProcedure = "dbo.ResultTournamentTeam_SelectByTeamId";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var result = sqlConnection.Query<ResultTournamentTeam, Team, ResultTournamentTeam>( 
                storedProcedure,
                (resultTournamentTeam, team) =>
                {
                    resultTournamentTeam.Team = team;
                    return resultTournamentTeam;
                },
                new { TeamId = teamId },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();

            return result;
        }

    }
}
