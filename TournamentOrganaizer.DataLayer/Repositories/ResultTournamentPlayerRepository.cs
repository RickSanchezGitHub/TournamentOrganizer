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
    public class ResultTournamentPlayerRepository: BaseRepository
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

        public List<ResultTournamentPlayer> GetDataOfTournamentByRound(int tournamentId, int numberRound)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SelectByTournamentIdAndNumberRound]";

            var result = sqlConnection
                .Query<ResultTournamentPlayer, Player, ResultTournamentPlayer>
                (
                    storedProcedure,
                    (resultTournamentPlayer, player) =>
                    {
                        resultTournamentPlayer.Player = player;
                        return resultTournamentPlayer;
                    },
                    new { TournamentId = tournamentId, NumberRound = numberRound },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                )
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

        public void InsertPlayerIdRoundMatchTournament(int playerId, int round, int match, int tournament)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_InsertPlayerIdRoundMatchTournament]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = playerId,
                        NumberRound = round,
                        NumberMatch = match,
                        TournamentId = tournament
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void InsertPlayerIdRoundMatchTournament(ResultTournamentPlayer resultTournamentPlayer)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_InsertPlayerIdRoundMatchTournament]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = resultTournamentPlayer.Player.Id,
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

        public int SetPlayerResultInRoundOfTournament(int newResult, int playerId, int numberRound, int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SetPlayerResultInRoundOfTournament]";

            return sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = playerId,
                        newResult = newResult,
                        NumberRound = numberRound,
                        TournamentId = tournamentId
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void SetMatchRoundByPlayerTournament(int tournamentId, int playerId, int numMatch, int numRound)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SetMatchRoundByPlayerAndTournament]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        TournamentId = tournamentId,
                        PlayerId = playerId,
                        NumberMatch = numMatch,
                        NumberRound = numRound
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void SetMatchRoundByPlayerTournament(ResultTournamentPlayer resultTournamentPlayer)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SetMatchRoundByPlayerAndTournament]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        TournamentId = resultTournamentPlayer.Tournament.Id,
                        PlayerId = resultTournamentPlayer.Id,
                        NumberMatch = resultTournamentPlayer.NumberMatch,
                        NumberRound = resultTournamentPlayer.NumberRound
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournament(int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_DeleteByTournamentId]";
           
            sqlConnection.Execute
                (
                    storedProcedure,
                    new { TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void AddPlayerToTournament(Player player, int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_InsertPlayerAndTournament]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = player.Id,
                        TournamentId = tournamentId
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void SetPlayerResultMatchRoundInTournament(int newResult, ResultTournamentPlayer resultTournamentPlayer)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SetPlayerResultMatchRoundInTournament]";

            var newRows = sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        TournamentId = resultTournamentPlayer.Tournament.Id,
                        PlayerId = resultTournamentPlayer.Player.Id,
                        newResult = newResult,
                        NumberMatch = resultTournamentPlayer.NumberMatch,
                        NumberRound = resultTournamentPlayer.NumberRound  
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public List<ResultTournamentPlayer> GetDataOfTournament(int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_GetDataOfTournament]";

            var result = sqlConnection
                .Query<ResultTournamentPlayer, Player, ResultTournamentPlayer>
                (
                    storedProcedure,
                    (resultTournamentPlayer, player) =>
                    {
                        resultTournamentPlayer.Player = player;
                        return resultTournamentPlayer;
                    },
                    new {TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                )
                .ToList();

            return result;
        }

        public int UpdatePlayerInMatchRoundTournament(int playerId, int tournamentId, int numberRound, int numberMatch)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_UpdatePlayerInMatchRoundTournament]";

            return sqlConnection.Execute
                (
                    storedProcedure,
                    new
                    {
                        PlayerId = playerId,
                        TournamentId = tournamentId,
                        NumberRound = numberRound,
                        NumberMatch = numberMatch
                    },
                    commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournamentRound(int tournamentId, int numberRound)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_DeleteByTournamentAndRound]";

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

    }
}
