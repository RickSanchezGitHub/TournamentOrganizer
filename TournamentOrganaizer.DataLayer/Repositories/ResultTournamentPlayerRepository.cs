using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.DataLayer.Entities;
using Dapper;
using System.Data;
using TournamentOrganaizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public class ResultTournamentPlayerRepository
    {
        string ConnectionString = @"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Initial Catalog=TournamentOrganizer.DB;Integrated Security=True;";


        public List<ResultTournamentPlayer> GetPlayerResultsInAllTournaments(Player player)
        {

            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var result = sqlConnection.Query<ResultTournamentPlayer, Player, ResultTournamentPlayer>(
                "dbo.ResultTournamentPlayer_SelectPlayerResultsInAllTournaments",
                (resultTournamentPlayer, player) =>
                {
                    resultTournamentPlayer.Player = player;
                    return resultTournamentPlayer;
                },
                new { PlayerId = player.Id },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();

            return result;
        }

        public List<Player> GetPlayersInTournament(Tournament tournament)
        {

            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var playerDictionary = new Dictionary<int, Player>();

            var result = sqlConnection.Query<Player, ResultTournamentPlayer, Player>(
                "[dbo].[ResultTournamentPlayer_SelectPlayersInTournament]",
                (player, ResultTournamentPlayer) =>
                {
                    if (!playerDictionary.TryGetValue(player.Id, out var playerEntry))
                    {
                        playerEntry = player;
                        playerDictionary.Add(playerEntry.Id, playerEntry);
                    }
                    return playerEntry;
                },
                new { TournamentId = tournament.Id },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).Distinct()
                .ToList();

            return result;
        }

        public List<ResultTournamentPlayer> GetPlayerResultsInTournament(Player player, Tournament tournament)
        {

            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var result = sqlConnection.Query<ResultTournamentPlayer, Player, ResultTournamentPlayer>(
                "dbo.ResultTournamentPlayer_SelectPlayerInTournament",
                (resultTournamentPlayer, player) =>
                {
                    resultTournamentPlayer.Player = player;
                    resultTournamentPlayer.Tournament = tournament;
                    return resultTournamentPlayer;
                },
                new { PlayerId = player.Id, TournamentId = tournament.Id },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();

            return result;
        }

        public void Insert(Player player, int result, int round, int match, Tournament tournament)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var newRows = sqlConnection.Execute("[dbo].[ResultTournamentPlayer_Insert]",
                new
                {
                    PlayerId = player.Id,
                    Result = result,
                    NumberRound = round,
                    NumberMatch = match,
                    TournamentId = tournament.Id
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public void SetPlayerResultInRoundOfTournament(Player player, int newResult, int round, Tournament tournament)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var newRows = sqlConnection.Execute("[dbo].[ResultTournamentPlayer_SetPlayerResultInRoundOfTournament]",
                new
                {
                    PlayerId = player.Id,
                    newResult = newResult,
                    NumberRound = round,
                    TournamentId = tournament.Id
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournament(Tournament tournament)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            sqlConnection.Execute("[dbo].[ResultTournamentPlayer_DeleteByTournamentId]",
                new {TournamentId = tournament.Id},
                commandType: CommandType.StoredProcedure
                );
        }

    }
}
