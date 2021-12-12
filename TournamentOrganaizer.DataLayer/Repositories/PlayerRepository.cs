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
    public class PlayerRepository
    {
        private string ConnectionString = RepositoryHelpers.ConnectionString;
        public int PlayerInsert(Player player)
        {
            int result = 0;
            var procName = "Player_Insert";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                int? Id = db.Query<int>(procName, new
                {
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    NickName = player.NickName,
                    Email = player.Email,
                    Birthday = player.Birthday
                },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                if(Id is null)
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

        public void PlayerDelete(int id)
        {
            const string procedureName = "Player_Delete";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                int? Id = db.Execute(procedureName, new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Player> PlayerGetAll()
        {
            const string procedureName = "Player_SelectAll";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Player>(procedureName, commandType: CommandType.StoredProcedure).ToList();
            }
        }      
     
        public Player PlayerGetById(int id)
        {
            const string procedureName = "Player_SelectById";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return db.Query<Player>(procedureName, new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        
        public void PlayerUpdate(int id, Player player)
        {
            const string procedureName = "Player_Update";
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                db.Execute(procedureName, new
                {
                    Id = id,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    NickName = player.NickName,
                    Email = player.Email,
                    Birthday = player.Birthday
                },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }     
}
