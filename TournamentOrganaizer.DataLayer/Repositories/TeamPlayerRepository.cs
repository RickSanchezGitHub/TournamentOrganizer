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
            int id = 0;
            using IDbConnection sqlConnection = ProvideConnection();


            id = sqlConnection.ExecuteScalar<int>(
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

        public void Delete(int teamid, int playerId)
        {
            const string procedureName = "Team_Player_Delete";
            using IDbConnection sqlConnection = ProvideConnection();

            sqlConnection.Execute(
                    procedureName,
                    new
                    {
                        TeamId = teamid,
                        PlayerId = playerId
                    },
                    commandType: CommandType.StoredProcedure
                );

        }

        public List<Team> GetTeamsByPlayerId(int playerId)
        {
            const string procedureName = "[dbo].[Team_Player_SelectByPlayerId]";
            using IDbConnection sqlConnection = ProvideConnection();

            var teamDictionary = new Dictionary<int, Team>();
            var result = sqlConnection
               .Query<TeamPlayer, Team, Team>
                (
                   procedureName,
                   (teamPlayer, team) =>
                   {
                       if (!teamDictionary.TryGetValue(team.Id, out var teamEntry))
                       {
                           teamEntry = team;
                           teamDictionary.Add(teamEntry.Id, teamEntry);
                       }
                       teamPlayer.TeamId = teamEntry.Id;
                       return teamEntry;
                   },
                   new { PlayerId = playerId },
                   commandType: CommandType.StoredProcedure,
                   splitOn: "Id"
                )
               .Distinct()
               .ToList();

            return result;
        }

    }
}
