using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service.TeamService
{
    public interface ITeamService
    {
        void Delete(int id);
        List<TeamModel> GetAll();
        TeamModel GetById(int id);
        int Insert(TeamModel team);
        void Update(int id, TeamModel team);
    }
}
