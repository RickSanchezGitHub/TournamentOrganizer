using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service.TeamPlayerService
{
    public class TeamPlayerService : ITeamPLayerService
    {
        private readonly ITeamPlayerRepository _teamPlayerRepository;

        public TeamPlayerService()
        {
            _teamPlayerRepository = new TeamPlayerRepository();
        }

        public void Insert(TeamPlayerModel teamPlayerModel)
        {
            var entity = CustomMapper.GetInstance().Map<TeamPlayer>(teamPlayerModel);
            _teamPlayerRepository.Insert(entity);
        }

        public void Delete(TeamPlayerModel teamPlayerModel)
        {
            var entity = CustomMapper.GetInstance().Map<TeamPlayer>(teamPlayerModel);
            _teamPlayerRepository.Delete(entity);
        }
    }
}
