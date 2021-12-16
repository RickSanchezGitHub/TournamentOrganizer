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
    public class TournamentRepository : Repository
    {
        public void TournamentInsert(Tournament tournament)
        {
            const string procedureName = "Tournament_Insert";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(
                procedureName,
                new
                {
                    Name = tournament.Name,
                    StartDate = tournament.StartDate,
                    CloseDate = tournament.CloseDate,
                    GameId = tournament.Game.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public void TournamentDeleteById(int id)
        {
            const string procedureName = "Tournament_DeleteById";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(
                procedureName,
                new
                { Id = id },
                commandType: CommandType.StoredProcedure
            );

        }

        public List<Tournament> TournamentSelectByAll()
        {
            const string procedureName = "Tournament_SelectByAll";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var resultList = connection.Query<Tournament, Game, Tournament>(
                procedureName,
                (tournament, game) =>
                {
                    tournament.Game = game;
                    return tournament;
                },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
            ).ToList();
            return resultList;
        }

        public Tournament TournamentSelectById(int id)
        {
            const string procedureName = "Tournament_SelectById";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var result = connection.Query<Tournament, Game, Tournament>(
                procedureName,
                (tournament, game) =>
                {
                    tournament.Game = game;
                    return tournament;
                },
                new { Id = id },
                commandType: CommandType.StoredProcedure,
                splitOn: "Id"
            ).FirstOrDefault();
            return result;
        }

        public void TournamentUpdateById(Tournament tournament)
        {
            const string procedureName = "Tournament_UpdateById";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            connection.Execute(
                procedureName,
                new
                {
                    Name = tournament.Name,
                    StartDate = tournament.StartDate,
                    CloseDate = tournament.CloseDate,
                    GameId = tournament.Game.Id
                },
                commandType: CommandType.StoredProcedure
            );
        }


    }
}
