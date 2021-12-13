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
    public class Team_PlayerRepository
    {
        private string _connectionString = RepositoryHelpers.ConnectionString;

        public int Insert(Team_Player team_player)
        {
            var procName = "Team_Player_Insert";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int id = db.ExecuteScalar<int>(procName, new
                {
                    TeamId = team_player.TeamId,
                    PlayerId = team_player.PlayerId
                },
                    commandType: CommandType.StoredProcedure);
                return id;
            }
        }

        public void Delete(int teamid, int playerId)
        {
            const string procedureName = "Team_Player_Delete";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int? Id = db.Execute(procedureName, new {
                    TeamId = teamid,
                    PlayerId = playerId
                }, commandType: CommandType.StoredProcedure);
            }
        }    
    }
}
