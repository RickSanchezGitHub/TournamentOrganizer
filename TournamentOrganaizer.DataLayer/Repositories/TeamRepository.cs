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
    public class TeamRepository : Repository
    {
        public int Insert(Team team)
        {
            int id = 0;
            var procName = "Team_Insert";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                id = db.ExecuteScalar<int>(procName, new
                {
                    Name = team.Name
                },
                    commandType: CommandType.StoredProcedure);
            }
            return id;
        }

        public void Delete(int id)
        {
            const string procedureName = "Team_Delete";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(procedureName, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Team> GetAll()
        {
            const string procedureName = "Team_SelectAll";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Team>(procedureName, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Team> GetById(int id)
        {
            const string procedureName = "Team_SelectById";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var teamDictionary = new Dictionary<int, Team>();

                var list = db.Query<Team, Player, Team>(
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
                    }, new { Id = id },
                    splitOn: "Id", commandType: CommandType.StoredProcedure)
                    .Distinct()
                    .ToList();
                return list;
            }
        }

        public void Update(int id, Team team)
        {
            const string procedureName = "Team_Update";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(procedureName, new
                {
                    Id = id,
                    Name = team.Name
                },
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}
