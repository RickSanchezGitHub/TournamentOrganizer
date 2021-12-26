using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public class TeamPlayerService : ITeamPlayerService
    { 
        private readonly TeamPlayerRepository _teamPlayerRepository;
        public TeamPlayerService() => _teamPlayerRepository = new TeamPlayerRepository();
        public int Insert(TeamPlayerModel teamPlayer)
        {
            var entity = CustomMapper.GetInstance().Map<TeamPlayer>(teamPlayer);
            int id = _teamPlayerRepository.Insert(entity);
            return id;
        }
        public void Delete(TeamPlayer teamPlayer)
        {
            var entity = CustomMapper.GetInstance().Map<TeamPlayer>(teamPlayer);
            _teamPlayerRepository.Delete(entity);
        }
    }
}
