using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service
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