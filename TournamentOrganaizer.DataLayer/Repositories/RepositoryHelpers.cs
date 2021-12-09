using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganaizer.DataLayer.Repositories
{
    public static class RepositoryHelpers
    {
        public static string GetConnectionString()
        {
            
            return "Server=(localdb)\\mssqllocaldb;Database=TournamentOrganaizer;Trusted_Connection=True";
            //return "Data Source=80.78.240.16;Persist Security Info=False;User ID=student;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        }
    }
}
