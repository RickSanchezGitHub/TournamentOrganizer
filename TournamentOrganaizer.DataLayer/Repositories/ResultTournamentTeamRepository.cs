using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.DataLayer.Entities;
using Dapper;
using TournamentOrganaizer.DataLayer.Entities;
using System.Data.SqlClient;
using System.Data;

namespace TournamentOrganizer.DataLayer.Repositories
{
    class ResultTournamentTeamRepository
    {
        

        string ConnectionString = @"Data Source=DESKTOP-JFRNH1K;Initial Catalog = TournamentOrganizer.DB;Integrated Security=True";
       
        public void Insert(Team team, int result, int round, int match, Tournament tournament)
        {
            string storedProcedure = "[dbo].[ResultTournamentTeam_Insert]";
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            var newRows = sqlConnection.Execute(storedProcedure,
                new
                {
                    TeamId = team.Id,
                    Result = result,
                    NumberRound = round,
                    NumberMatch = match,
                    TournamentId = tournament.Id
                },
                commandType: CommandType.StoredProcedure
                );
        }

        public void DeleteByTournament(Tournament tournament)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            sqlConnection.Execute("[dbo].[ResultTournamentTeam_DeleteByTournamentId]",
                new { TournamentId = tournament.Id },
                commandType: CommandType.StoredProcedure
                );
        }

    }
}
