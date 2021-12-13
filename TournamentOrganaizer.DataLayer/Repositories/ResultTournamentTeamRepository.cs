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

namespace TournamentOrganizer.DataLayer.Repositories
{
    class ResultTournamentTeamRepository
    {
        

        string ConnectionString = @"Data Source=(local);Initial Catalog = TournamentOrganizer.DB;Integrated Security=True";
       
        public void Insert(Team team, int result, int round, int match, Tournament tournament)
        {
            string storedProcedure = "[dbo].[ResultTournamentTeam_Insert]";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var newRows = sqlConnection.Execute(storedProcedure,
                new
                {
                    TeamId = team.Id,
                    Result = result,
                    NumberRound = round,
                    NumberMatch = match,
                    TournamentId = tournament.Id
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournament(Tournament tournament)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            sqlConnection.Execute("[dbo].[ResultTournamentTeam_DeleteByTournamentId]",
                new { TournamentId = tournament.Id },
                commandType: CommandType.StoredProcedure
                );
        }

        public void SetPlayerResultInRoundOfTournament(Team team, int newResult, int round, Tournament tournament)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var newRows = sqlConnection.Execute("[dbo].[ResultTournamentTeam_SetTeamResultInRoundOfTournament]",
                new
                {
                    TeamId = team.Id,
                    newResult = newResult,
                    NumberRound = round,
                    TournamentId = tournament.Id
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public List<ResultTournamentTeam> GetTeamsResultsInTournament(Team team, Tournament tournament)
        {

            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var result = sqlConnection.Query<ResultTournamentTeam, Team, ResultTournamentTeam>(
                "dbo.ResultTournamentTeam_SelectByTeamIdAndTournamentId",
                (resultTournamentTeam, team) =>
                {
                    resultTournamentTeam.Team = team;
                    resultTournamentTeam.Tournament = tournament;
                    return resultTournamentTeam;
                },
                new { TeamId = team.Id, TournamentId = tournament.Id },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();

            return result;
        }

        public List<Team> GetTeamsInTournament(Tournament tournament)
        {

            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var teamDictionary = new Dictionary<int, Team>();

            var result = sqlConnection.Query<Team, ResultTournamentTeam, Team>(
                "[dbo].[ResultTournamentTeam_SelectByTournamentId]",
                (team, ResultTournamentTeam) =>
                {
                    if (!teamDictionary.TryGetValue(team.Id, out var teamEntry))
                    {
                        teamEntry = team;
                        teamDictionary.Add(teamEntry.Id, teamEntry);
                    }
                    return teamEntry;
                },
                new { TournamentId = tournament.Id },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).Distinct()
                .ToList();

            return result;
        }

        public List<ResultTournamentTeam> GetPlayerResultsInAllTournaments(Team team)
        {

            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var result = sqlConnection.Query<ResultTournamentTeam, Team, ResultTournamentTeam>(
                "dbo.ResultTournamentTeam_SelectByTeamId",
                (resultTournamentTeam, team) =>
                {
                    resultTournamentTeam.Team = team;
                    return resultTournamentTeam;
                },
                new { TeamId = team.Id },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();

            return result;
        }

    }
}
