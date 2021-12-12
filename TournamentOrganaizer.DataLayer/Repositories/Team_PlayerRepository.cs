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
        private string ConnectionString = RepositoryHelpers.ConnectionString;

        public int Insert(Team_Player team_player)
        {
            int result = 0;
            var procName = "Team_Player_Insert";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                int? Id = db.Query<int>(procName, new
                {
                    TeamId = team_player.TeamId,
                    PlayerId = team_player.PlayerId
                },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (Id is null)
                {
                    return result;
                }
                else
                {
                    result = Id.Value;
                }
            }
            return result;
        }

        public void Delete(int Teamid, int PlayerId)
        {
            const string procedureName = "Team_Player_Delete";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                int? Id = db.Execute(procedureName, new { Teamid }, commandType: CommandType.StoredProcedure);
            }
        }       

        public List<Team_Player> GetById(int TeamId)
        {
            const string procedureName = "Team_PlayerSelectByTeamId";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Team_Player>(procedureName, new { TeamId }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }     
    }
}
