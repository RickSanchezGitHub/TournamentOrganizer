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
    public class ResultTournamentTeamRepository : BaseRepository, IResultTournamentTeamRepository
    {
        //public void Insert(ResultTournamentTeam resultTournamentTeam)
        //{
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_Insert]";
        //    using IDbConnection sqlConnection = ProvideConnection();

        //    var newRows = sqlConnection.Execute(storedProcedure,
        //        new
        //        {
        //            TeamId = resultTournamentTeam.Team.Id,
        //            Result = resultTournamentTeam.Result,
        //            NumberRound = resultTournamentTeam.NumberRound,
        //            NumberMatch = resultTournamentTeam.NumberMatch,
        //            TournamentId = resultTournamentTeam.Tournament.Id
        //        },
        //        commandType: CommandType.StoredProcedure
        //        );
        //}

        //public void DeleteByTournament(int tournamentId)
        //{
        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_DeleteByTournamentId]";
        //    sqlConnection.Execute
        //        (
        //            storedProcedure,
        //            new { TournamentId = tournamentId },
        //            commandType: CommandType.StoredProcedure
        //        );
        //}

        public void SetTeamResultInRoundOfTournament(ResultTournamentTeam resultTournamentTeam, int newResult)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_SetTeamResultInRoundOfTournament]";
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

        //public void SetTeamResultInRoundOfTournament(int teamId, int newResult, int numberRound, int tournamentId)
        //{
        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_SetTeamResultInRoundOfTournament]";
        //    var newRows = sqlConnection.Execute(
        //            storedProcedure,
        //            new
        //            {
        //                newResult = newResult,
        //                TeamId = teamId,
        //                TournamentId = tournamentId,
        //                NumberRound = numberRound
        //            },
        //            commandType: CommandType.StoredProcedure
        //        );
        //}

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

        //public List<ResultTournamentTeam> GetTeamResultsInAllTournaments(int teamId)
        //{

        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "dbo.ResultTournamentTeam_SelectByTeamId";
        //    var result = sqlConnection.Query<ResultTournamentTeam, Tournament, ResultTournamentTeam>
        //        (
        //            storedProcedure,
        //            (resultTournamentTeam, tournament) =>
        //            {
        //                resultTournamentTeam.Tournament = tournament;
        //                return resultTournamentTeam;
        //            },
        //            new { TeamId = teamId },
        //            commandType: CommandType.StoredProcedure,
        //            splitOn: "Id"
        //        )
        //        .ToList();

        //    return result;
        //}

        public List<ResultTournamentTeam> GetDataOfTournament(int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_GetDataOfTournament]";

            var result = sqlConnection
                .Query<ResultTournamentTeam, Team, ResultTournamentTeam>
                (
                    storedProcedure,
                    (resultTournamentTeam, team) =>
                    {
                        resultTournamentTeam.Team = team;
                        return resultTournamentTeam;
                    },
                    new { TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                )
                .ToList();

            return result;
        }

        public List<ResultTournamentTeam> GetTeamsResultsInTournamentRound(int tournamentId, int numberRound)
        {

            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_SelectByTournamentIdAndNumberRound]";

            var playerDictionary = new Dictionary<int, Team>();

            var result = sqlConnection
                .Query<ResultTournamentTeam, Team, ResultTournamentTeam>
                 (
                    storedProcedure,
                    (resultTournamentTeam, team) =>
                    {
                        if (!playerDictionary.TryGetValue(team.Id, out var teamEntry))
                        {
                            teamEntry = team;
                            playerDictionary.Add(teamEntry.Id, teamEntry);
                        }
                        resultTournamentTeam.Team = teamEntry;
                        return resultTournamentTeam;
                    },
                    new { TournamentId = tournamentId, NumberRound = numberRound },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                 )
                .Distinct()
                .ToList();

            return result;
        }

        //public void SetMatchRoundInTournamentByTeamId(int tournamentId, int teamId, int numMatch, int numRound)
        //{
        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_SetMatchRoundInTournamentByTeamId]";

        //    var newRows = sqlConnection.Execute
        //        (
        //            storedProcedure,
        //            new
        //            {
        //                TournamentId = tournamentId,
        //                TeamId = teamId,
        //                NumberMatch = numMatch,
        //                NumberRound = numRound
        //            },
        //            commandType: CommandType.StoredProcedure
        //        );
        //}

        //public void SetMatchRoundInTournamentByTeamId(ResultTournamentTeam resultTournamentTeam)
        //{
        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_SetMatchRoundInTournamentByTeamId]";

        //    var newRows = sqlConnection.Execute
        //        (
        //            storedProcedure,
        //            new
        //            {
        //                TournamentId = resultTournamentTeam.Tournament.Id,
        //                TeamId = resultTournamentTeam.Team.Id,
        //                NumberMatch = resultTournamentTeam.NumberMatch,
        //                NumberRound = resultTournamentTeam.NumberRound
        //            },
        //            commandType: CommandType.StoredProcedure
        //        );
        //}

        //public void InsertTeamIdRoundMatchTournament(int teamId, int round, int match, int tournament)
        //{
        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_InsertTeamIdRoundMatchTournament]";

        //    var newRows = sqlConnection.Execute
        //        (
        //            storedProcedure,
        //            new
        //            {
        //                TeamId = teamId,
        //                NumberRound = round,
        //                NumberMatch = match,
        //                TournamentId = tournament
        //            },
        //            commandType: CommandType.StoredProcedure
        //        );
        //}

        public int InsertTeamIdRoundMatchTournament(ResultTournamentTeam resultTournamentTeam)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_InsertTeamIdRoundMatchTournament]";

            return sqlConnection.ExecuteScalar<int>
                (
                    storedProcedure,
                    new
                    {
                        TeamId = resultTournamentTeam.Team.Id,
                        NumberRound = resultTournamentTeam.NumberRound,
                        NumberMatch = resultTournamentTeam.NumberMatch,
                        TournamentId = resultTournamentTeam.Tournament.Id
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        //public int UpdateTeamInMatchRoundTournament(int teamId, int tournamentId, int numberRound, int numberMatch)
        //{
        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_UpdateTeamInMatchRoundTournament]";

        //    return sqlConnection.Execute
        //        (
        //            storedProcedure,
        //            new
        //            {
        //                TeamId = teamId,
        //                TournamentId = tournamentId,
        //                NumberRound = numberRound,
        //                NumberMatch = numberMatch
        //            },
        //            commandType: CommandType.StoredProcedure
        //        );
        //}

        //public int UpdateTeamInMatchRoundTournament(ResultTournamentTeam resultTournamentTeam)
        //{
        //    using IDbConnection sqlConnection = ProvideConnection();
        //    string storedProcedure = "[dbo].[ResultTournamentTeam_UpdateTeamInMatchRoundTournament]";

        //    return sqlConnection.Execute
        //        (
        //            storedProcedure,
        //            new
        //            {
        //                TeamId = resultTournamentTeam.Team.Id,
        //                TournamentId = resultTournamentTeam.Tournament.Id,
        //                NumberRound = resultTournamentTeam.NumberRound,
        //                NumberMatch = resultTournamentTeam.NumberMatch
        //            },
        //            commandType: CommandType.StoredProcedure
        //        );
        //}

        public void DeleteByTournamentRound(int tournamentId, int numberRound)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_DeleteByTournamentAndRound]";

            sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        TournamentId = tournamentId,
                        NumberRound = numberRound
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTeamIdAndTournamentId(int teamId, int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentTeam_DeleteByTeamIdAndTournamentId]";

            sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        TeamId = teamId,
                        TournamentId = tournamentId
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

    }
}
