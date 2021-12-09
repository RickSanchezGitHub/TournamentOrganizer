using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    class ResultTournamentPlayerRepository
    {
        private const string _connectionString = "Data Source=LAPTOP-7HPLQHLI/TEW_SQLEXPRESS;Database=TournamentOrganizer.DB;Trusted_Connection=True;";

        public ResultTournamentPlayer GetResultTournamentPlayerByPlayerIdAndTournamentId( int PlayerId, int TournamentId)
        {
            const string procName = "dbo.ResultTournamentPlayer_SelectByPlayerIdAndTournamentId";

            using var connection = new SqlConnection(_connectionString);

            using var command = new SqlCommand(procName, connection);

            command.Parameters.AddWithValue("@PlayerId", PlayerId);
            command.Parameters.AddWithValue("@TiurnamentId", TournamentId);

            var result = new ResultTournamentPlayer();

            try
            {
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new ResultTournamentPlayer
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(nameof(ResultTournamentPlayer.Id))),
                        PlayerId = reader.GetInt32(reader.GetOrdinal(nameof(ResultTournamentPlayer.PlayerId))),
                        Result = reader.GetInt32(reader.GetOrdinal(nameof(ResultTournamentPlayer.Result))),
                        NumberRound = reader.GetInt32(reader.GetOrdinal(nameof(ResultTournamentPlayer.NumberRound))),
                        NumberGame = reader.GetInt32(reader.GetOrdinal(nameof(ResultTournamentPlayer.NumberGame))),
                        TournamentId = reader.GetInt32(reader.GetOrdinal(nameof(ResultTournamentPlayer.TournamentId)))
                    };
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        

        
    }
}
