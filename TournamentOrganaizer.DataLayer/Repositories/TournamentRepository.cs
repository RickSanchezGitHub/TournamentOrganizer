using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TournamentOrganaizer.DataLayer.Entities;

namespace TournamentOrganaizer.DataLayer.Repositories
{
    public class TournamentRepository
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TournamentOrganaizer;Trusted_Connection=True";
        public void TournamentInsert(string name, DateTime startDate, DateTime closeDate, Game game)
        {
            const string procedureName = "Tournament_Insert";                        
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@CloseDate", closeDate);
            command.Parameters.AddWithValue("@GameId", game.Id);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void TournamentDeleteById(int id)
        {
            const string procedureName = "Tournament_DeleteById";
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Tournament> TournamentSelectByAll()
        {
            const string procedureName = "Tournament_SelectByAll";
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            var resultList = new List<Tournament>();
            var result = new Tournament();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new Tournament
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(nameof(Tournament.Id))),
                        Name = reader.GetString(reader.GetOrdinal(nameof(Tournament.Name))),
                        StartDate = reader.GetDateTime(reader.GetOrdinal(nameof(Tournament.StartDate))),
                        CloseDate = reader.GetDateTime(reader.GetOrdinal(nameof(Tournament.CloseDate))),
                        GameId = reader.GetInt32(reader.GetOrdinal(nameof(Tournament.GameId)))
                    };
                    resultList.Add(result);
                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultList;
        }

        public Tournament TournamentSelectById(int id)
        {
            const string procedureName = "Tournament_SelectById";
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            var result = new Tournament();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new Tournament
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(nameof(Tournament.Id))),
                        Name = reader.GetString(reader.GetOrdinal(nameof(Tournament.Name))),
                        StartDate = reader.GetDateTime(reader.GetOrdinal(nameof(Tournament.StartDate))),
                        CloseDate = reader.GetDateTime(reader.GetOrdinal(nameof(Tournament.CloseDate))),
                        GameId = reader.GetInt32(reader.GetOrdinal(nameof(Tournament.GameId)))
                    };

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public void TournamentUpdateById(int id, string name, DateTime startDate, DateTime closeDate, Game game)
        {
            const string procedureName = "Tournament_UpdateById";
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@CloseDate", closeDate);
            command.Parameters.AddWithValue("@GameId", game.Id);
            try
            {
                connection.Open();
                var reader = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
