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

    public class GameRepository: BaseRepository
    {
        public void GameInsert(string name)
        {
            const string procedureName = "Game_Insert";
            using IDbConnection connection = ProvideConnection();
            connection.Execute(
                procedureName,
                new { Name = name },
                commandType: CommandType.StoredProcedure
            );
        }

        public void GameDeleteById(int id)
        {
            const string procedureName = "Game_DeleteById";
            using IDbConnection connection = ProvideConnection();
            connection.Execute(
                procedureName,
                new { Id = id },
                commandType: CommandType.StoredProcedure
            );
        }

        public List<Game> GameSelectByAll()
        {
            const string procedureName = "Game_SelectByAll";
            using IDbConnection connection = ProvideConnection();
            var resultList = connection.Query<Game>(
                procedureName, 
                commandType: CommandType.StoredProcedure
            ).ToList();
            return resultList;
        }

        public Game GameSelectById(int id)
        {
            const string procedureName = "Game_SelectById";
            using IDbConnection connection = ProvideConnection();
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
            using IDbConnection connection = ProvideConnection();
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
