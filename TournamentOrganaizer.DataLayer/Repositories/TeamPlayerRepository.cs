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
    public class TeamPlayerRepository : BaseRepository
    {
        public int Insert(TeamPlayer teamPlayer)
        {
            var procName = "Team_Player_Insert";
            using IDbConnection sqlConnection = ProvideConnection();


            int id = sqlConnection.ExecuteScalar<int>(
                    procName,
                    new
                    {
                        TeamId = teamPlayer.TeamId,
                        PlayerId = teamPlayer.PlayerId
                    },
                   commandType: CommandType.StoredProcedure
               );

            return id;
        }

        public void Delete(TeamPlayer teamPlayer)
        {
            const string procedureName = "Team_Player_Delete";
            using IDbConnection sqlConnection = ProvideConnection();

            sqlConnection.Execute(
                    procedureName,
                    new
                    {
                        TeamId = teamPlayer.TeamId,
                        PlayerId = teamPlayer.PlayerId
                    },
                    commandType: CommandType.StoredProcedure
                );

        }
    }
}
