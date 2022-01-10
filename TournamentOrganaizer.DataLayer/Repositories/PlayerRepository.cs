using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public class PlayerRepository : BaseRepository, IPlayerRepository
    {
        public int Insert(Player player)
        {
            var storedProcedure = "Player_Insert";
            int id = 0;
            using IDbConnection sqlConnection = ProvideConnection();


            id = sqlConnection.ExecuteScalar<int>
                (storedProcedure,
                new
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    NickName = player.Name,
                    Email = player.Email,
                    Birthday = player.Birthday
                },
                commandType: CommandType.StoredProcedure);
            return id;
        }

        public void Delete(int id)
        {
            const string procedureName = "Player_Delete";
            using IDbConnection sqlConnection = ProvideConnection();

            sqlConnection.Execute
                (
                    procedureName,
                    new { id },
                    commandType: CommandType.StoredProcedure
                );
        }

        public List<Player> GetAll()
        {
            const string procedureName = "Player_SelectAll";
            using IDbConnection sqlConnection = ProvideConnection();

            var result = sqlConnection.Query<Player>
                (
                    procedureName,
                    commandType: CommandType.StoredProcedure
                )
                .ToList();

            return result;
        }

        public Player GetById(int id)
        {
            const string procedureName = "Player_SelectById";
            using IDbConnection sqlConnection = ProvideConnection();
            var result = sqlConnection.Query<Player>
                (
                    procedureName,
                    new { id },
                    commandType: CommandType.StoredProcedure
                )
                .FirstOrDefault();
            return result;
        }

        public void Update(int id, Player player)
        {
            const string procedureName = "Player_Update";
            using IDbConnection sqlConnection = ProvideConnection();

            sqlConnection.Execute(
                    procedureName,
                    new
                    {
                        Id = id,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        NickName = player.Name,
                        Birthday = player.Birthday
                    },
                    commandType: CommandType.StoredProcedure
                );

        }

        public List<Player> GetPlayersInTournament(int tournamentId)
        {
            using IDbConnection sqlConnection = ProvideConnection();
            string storedProcedure = "[dbo].[ResultTournamentPlayer_SelectPlayersInTournament]";

            var playerDictionary = new Dictionary<int, Player>();

            var result = sqlConnection
                .Query<Player, ResultTournamentPlayer, Player>
                 (
                    storedProcedure,
                    (player, resultTournamentPlayer) =>
                    {
                        if (!playerDictionary.TryGetValue(player.Id, out var playerEntry))
                        {
                            playerEntry = player;
                            playerDictionary.Add(playerEntry.Id, playerEntry);
                        }
                        resultTournamentPlayer.Player = playerEntry;
                        return playerEntry;
                    },
                    new { TournamentId = tournamentId },
                    commandType: CommandType.StoredProcedure,
                    splitOn: "Id"
                 )
                .Distinct()
                .ToList();

            return result;
        }
    }
}
