using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TournamentOrganaizer.DataLayer.Entities;
using Dapper;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganaizer.DataLayer.Repositories
{

    public class GameRepository: Repository
    {
        public void GameInsert(string name)
        {
            const string procedureName = "Game_Insert";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(
                procedureName,
                new { Name = name },
                commandType: CommandType.StoredProcedure
            );
        }

        public void GameDeleteById(int id)
        {
            const string procedureName = "Game_DeleteById";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(
                procedureName,
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public List<Game> GameSelectByAll()
        {
            const string procedureName = "Game_SelectByAll";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var resultList = connection.Query<Game>(
                procedureName, 
                commandType: CommandType.StoredProcedure
            ).ToList();
            return resultList;
        }

        public Game GameSelectById(int id)
        {
            const string procedureName = "Game_SelectById";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var result = connection.Query<Game>(
                procedureName,
                new { Id = id },
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
            return result;
        }

        public void GameUpdate(int id, string name)
        {
            const string procedureName = "Game_Update";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var result = connection.Execute(
                procedureName,
                new { 
                    Id = id ,
                    Name = name
                    },
                commandType: CommandType.StoredProcedure
            );
        }

    }
}
