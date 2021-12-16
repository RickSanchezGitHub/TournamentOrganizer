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
    public class TeamPlayerRepository : Repository
    {
        public int Insert(TeamPlayer teamPlayer)
        {
            var procName = "Team_Player_Insert";
            int id = 0;
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                id = db.ExecuteScalar<int>(procName, new
                {
                    TeamId = teamPlayer.TeamId,
                    PlayerId = teamPlayer.PlayerId
                },
                   commandType: CommandType.StoredProcedure);
            }
            return id;
        }

        public void Delete(int teamid, int playerId)
        {
            const string procedureName = "Team_Player_Delete";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(procedureName, new
                {
                    TeamId = teamid,
                    PlayerId = playerId
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
