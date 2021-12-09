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
    public class GameRepository
    {
        const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=TournamentOrganaizer;Trusted_Connection=True";
        public void GameInsert(string name)
        {
            const string procedureName = "Game_Insert";
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", name);

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
        public void GameDeleteById(int id)
        {
            const string procedureName = "Game_DeleteById";
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

        public List<Game> GameSelectByAll()
        {
            const string procedureName = "Game_SelectByAll";
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            var resultList = new List<Game>();
            var result = new Game();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new Game
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(nameof(Game.Id))),
                        Name = reader.GetString(reader.GetOrdinal(nameof(Game.Name))),
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

        public Game TournamentSelectById(int id)
        {
            const string procedureName = "Game_SelectById";
            using var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            var result = new Game();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new Game
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(nameof(Game.Id))),
                        Name = reader.GetString(reader.GetOrdinal(nameof(Game.Name))),
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

    }
}
