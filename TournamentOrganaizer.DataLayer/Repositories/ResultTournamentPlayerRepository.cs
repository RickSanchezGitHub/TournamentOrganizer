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
using TournamentOrganaizer.DataLayer.Repositories;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public class ResultTournamentPlayerRepository : BaseRepository, IResultTournamentPlayerRepository
    {
        public List<ResultTournamentPlayer> GetPlayerResultsInAllTournaments(int playerId)
        {

            using var sqlConnection = ProvideConnection();
            string storedProcedure = "dbo.ResultTournamentPlayer_SelectPlayerResultsInAllTournaments";

            var result = sqlConnection
                .Query<ResultTournamentPlayer, Player, ResultTournamentPlayer>
                 (
                    storedProcedure,
                    (resultTournamentPlayer, player) =>
                    {
                        resultTournamentPlayer.Player = player;
                        return resultTournamentPlayer;
                    },
                    new { PlayerId = playerId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                 )
                .ToList();

            return result;
        }

        public List<ResultTournamentPlayer> GetPlayersResultsInTournamentRound(int tournamentId, int numberRound)
        {

            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SelectByTournamentIdAndNumberRound]";

            var playerDictionary = new Dictionary<int, Player>();

            var result = sqlConnection
                .Query<ResultTournamentPlayer, Player, ResultTournamentPlayer>
                 (
                    storedProcedure,
                    (ResultTournamentPlayer, player) =>
                    {
                        if (!playerDictionary.TryGetValue(player.Id, out var playerEntry))
                        {
                            playerEntry = player;
                            playerDictionary.Add(playerEntry.Id, playerEntry);
                        }
                        ResultTournamentPlayer.Player = playerEntry;
                        return ResultTournamentPlayer;
                    },
                    new { TournamentId = tournamentId, NumberRound = numberRound },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                 )
                .Distinct()
                .ToList();

            return result;
        }

        public List<ResultTournamentPlayer> GetPlayerResultsInTournament(int playerId, int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "dbo.ResultTournamentPlayer_GetPlayerResultsInTournament";

            var result = sqlConnection
                .Query<ResultTournamentPlayer, Player, ResultTournamentPlayer>
                (
                    storedProcedure,
                    (resultTournamentPlayer, player) =>
                    {
                        resultTournamentPlayer.Player = player;
                        return resultTournamentPlayer;
                    },
                    new { PlayerId = playerId, TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                )
                .ToList();

            return result;
        }

        public void Insert(ResultTournamentPlayer resultTournamentPlayer)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_Insert]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = resultTournamentPlayer.Player.Id,
                        Result = resultTournamentPlayer.Result,
                        NumberRound = resultTournamentPlayer.NumberRound,
                        NumberMatch = resultTournamentPlayer.NumberMatch,
                        TournamentId = resultTournamentPlayer.Tournament.Id
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void SetPlayerResultInRoundOfTournament(int newResult, ResultTournamentPlayer resultTournamentPlayer)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SetPlayerResultInRoundOfTournament]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = resultTournamentPlayer.Player.Id,
                        newResult = newResult,
                        NumberRound = resultTournamentPlayer.NumberRound,
                        TournamentId = resultTournamentPlayer.Tournament.Id
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournament(int playerId, int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_DeleteByTournamentId]";

            sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        TournamentId = tournamentId,
                        PlayerId = playerId
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public List<Player> GetPlayersInTournamentsByTournamentId(int tournamentId)
        {
            using var sqlConnection = ProvideConnection();
            string storedProcedure = "dbo.ResultTournamentPlayer_SelectPlayersInTournament";

            var result = sqlConnection
                .Query<Player>
                 (
                    storedProcedure,
                    new { TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure
                 )

                .ToList();

            return result;
        }

        public int AddPlayerToTournament(Player player, int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_AddPlayerToTournament]";

            var playerId = sqlConnection.Query<int>
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = player.Id,
                        TournamentId = tournamentId
                    },
                    commandType: CommandType.StoredProcedure
                ).FirstOrDefault();
            return playerId;
        }
    }
}
