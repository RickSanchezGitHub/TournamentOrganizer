using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Entities;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.DataLayer.Entities;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public int Insert(Team team)
        {

            var procedureName = "Team_Insert";
            using IDbConnection sqlConnection = ProvideConnection();

            int id = sqlConnection.ExecuteScalar<int>(
                    procedureName,
                    new
                    {
                        Name = team.Name
                    },
                    commandType: CommandType.StoredProcedure
                );

            return id;
        }

        public void Delete(int id)
        {
            const string procedureName = "Team_Delete";
            using IDbConnection sqlConnection = ProvideConnection();

            sqlConnection.Execute(
                    procedureName,
                    new { id },
                    commandType: CommandType.StoredProcedure
                );

        }

        public List<Team> GetAll()
        {
            const string procedureName = "Team_SelectAll";
            using IDbConnection sqlConnection = ProvideConnection();

            var result = sqlConnection
                .Query<Team>
                (
                    procedureName,
                    commandType: CommandType.StoredProcedure
                )
                .ToList();
            return result;
        }

        public Team GetById(int id)
        {
            const string procedureName = "Team_SelectById";
            using IDbConnection sqlConnection = ProvideConnection();

            var teamDictionary = new Dictionary<int, Team>();

            var result = sqlConnection.Query<Team, Player, Team>(
                    procedureName,
                    (team, player) =>
                    {
                        Team teamEntry;

                        if (!teamDictionary.TryGetValue(team.Id, out teamEntry))
                        {
                            teamEntry = team;
                            teamEntry.Players = new List<Player>();
                            teamDictionary.Add(teamEntry.Id, teamEntry);
                        }

                        teamEntry.Players.Add(player);
                        return teamEntry;
                    },
                    new { Id = id },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure
                 ).FirstOrDefault();

            return result;

        }

        public void Update(int id, Team team)
        {
            const string procedureName = "Team_Update";
            using IDbConnection sqlConnection = ProvideConnection();

            sqlConnection.Execute(
                procedureName,
                new
                {
                    Id = id,
                    Name = team.Name
                },
                commandType: CommandType.StoredProcedure
            );

        }

        public List<Player> GetAvailablePlayersToAdd(int id)
        {
            const string procedureName = "Team_GetAvailablePlayersToAdd";
            using IDbConnection sqlConnection = ProvideConnection();

            var result = sqlConnection
                .Query<Player>
                (
                    procedureName,
                    commandType: CommandType.StoredProcedure,
                    param: new { TeamId = id }
                )
                .ToList();
            return result;
        }
    }
}
