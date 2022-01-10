using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.DataLayer.Repositories
{
    public abstract class BaseRepository
    {
        private const string _сonnectionString = "Data Source=80.78.240.16;Initial Catalog=TournamentOrganizer.DB;User ID=student;Password=qwe!23";
        protected IDbConnection ProvideConnection()
        {
            IDbConnection connection = new SqlConnection(_сonnectionString);
            return connection;
        }
    }
}
