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
    public class PlayerRepository
    {
        private string ConnectionString = RepositoryHelpers.ConnectionString;
        public void PlayerInsert(Player player)
        {
            const string procedureName = "Player_Insert";
            using var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(new[]
            {
                new SqlParameter("@FirstName", player.FirstName),
                new SqlParameter("@LastName", player.LastName),
                new SqlParameter("@NickName", player.NickName),
                new SqlParameter("@Email", player.Email),
                new SqlParameter("@Birthday", player.Birthday)
            });
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

        public void PlayerDelete(int id)
        {
            const string procedureName = "Player_Delete";
            using var connection = new SqlConnection(ConnectionString);
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

        public List<Player> PlayerSelectAll()
        {
            const string procedureName = "Player_SelectAll";
            using var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand(procedureName, connection);
            var resultList = new List<Player>();
            var result = new Player();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    resultList.Add(new Player
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(nameof(Player.Id))),
                        FirstName = reader.GetString(reader.GetOrdinal(nameof(Player.FirstName))),
                        LastName = reader.GetString(reader.GetOrdinal(nameof(Player.LastName))),
                        NickName = reader.GetString(reader.GetOrdinal(nameof(Player.NickName))),
                        Email = reader.GetString(reader.GetOrdinal(nameof(Player.Email))),
                        Birthday = reader.GetDateTime(reader.GetOrdinal(nameof(Player.Birthday)))
                    });
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

        public Player PlayerSelectById(int id)
        {
            const string procedureName = "Player_SelectById";
            using var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            var result = new Player();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    result = new Player
                    {
                        Id = reader.GetInt32(reader.GetOrdinal(nameof(Player.Id))),
                        FirstName = reader.GetString(reader.GetOrdinal(nameof(Player.FirstName))),
                        LastName = reader.GetString(reader.GetOrdinal(nameof(Player.LastName))),
                        NickName = reader.GetString(reader.GetOrdinal(nameof(Player.NickName))),
                        Email = reader.GetString(reader.GetOrdinal(nameof(Player.Email))),
                        Birthday = reader.GetDateTime(reader.GetOrdinal(nameof(Player.Birthday)))
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
        
        public void PlayerUpdate(int id, Player player)
        {
            const string procedureName = "Player_Update";
            using var connection = new SqlConnection(ConnectionString);
            var command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(new[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@FirstName", player.FirstName),
                new SqlParameter("@LastName", player.LastName),
                new SqlParameter("@NickName", player.NickName),
                new SqlParameter("@Email", player.Email),
                new SqlParameter("@Birthday", player.Birthday)
            });
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
    }    
}
