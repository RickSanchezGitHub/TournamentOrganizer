using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.DataLayer.Entities;
using Dapper;
using TournamentOrganaizer.DataLayer.Entities;
using System.Data;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public class ResultTournamentPlayerRepository
    {
        string ConnectionString = @"Data Source=LAPTOP-7HPLQHLI\TEW_SQLEXPRESS;Initial Catalog=TournamentOrganizer.DB;Integrated Security=True;";

        string selectSql = "SELECT " +
            "rtp.[Id]," +
            "rtp.[Result]," +
            "rtp.[NumberRound]," +
            "rtp.[NumberMatch]," +
            "p.Id," +
            "p.FirstName," +
            "p.LastName," +
            "p.NickName" +

            "FROM [dbo].[ResultTournamentPlayer] rtp inner join dbo.[Player] p  " +
            "ON rtp.PlayerId = p.Id" +
            //"inner join dbo.[Tournament] t" +
            //"ON rtp.TournamentId = t.Id" +
            "WHERE rtp.PlayerId = 1";

        public List<ResultTournamentPlayer> GetPlayerResultsInAllTournaments()
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
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
                ).ToList();
            return result;
        }
    }
}
