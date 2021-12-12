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
    public class TeamRepository
    {
        private string ConnectionString = RepositoryHelpers.ConnectionString;

        public int Insert(Team team)
        {
            int result = 0;
            var procName = "Team_Insert";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                int? Id = db.Query<int>(procName, new
                {
                    Name = team.Name                    
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

        public void Delete(int id)
        {
            const string procedureName = "Team_Delete";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                int? Id = db.Execute(procedureName, new { id }, commandType: CommandType.StoredProcedure);
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

        public Team GetById(int id)
        {
            const string procedureName = "Team_SelectById";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Team>(procedureName, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
