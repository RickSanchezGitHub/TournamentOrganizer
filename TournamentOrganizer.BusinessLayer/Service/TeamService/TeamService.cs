using System.Collections.Generic;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService()
        {
            _teamRepository = new TeamRepository();
        }
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public int Insert(TeamModel team)
        {
            var entity = CustomMapper.GetInstance().Map<Team>(team);
            var result = _teamRepository.Insert(entity);
            return result;
        }

        public void Delete(int id)
        {
            _teamRepository.Delete(id);
        }

        public List<TeamModel> GetAll()
        {
            var entity = _teamRepository.GetAll();
            var result = CustomMapper.GetInstance().Map<List<TeamModel>>(entity);
            return result;
        }

        public TeamModel GetById(int id)
        {
            var entity = _teamRepository.GetById(id);
            var result = CustomMapper.GetInstance().Map<TeamModel>(entity);
            return result;
        }
        public void Update(int id, TeamModel team)
        {
            var entity = CustomMapper.GetInstance().Map<Team>(team);
            _teamRepository.Update(id, entity);
        }

        public List<PlayerModel> GetAvailablePlayersToAdd(int id)
        {
            var entity = _teamRepository.GetAvailablePlayersToAdd(id);
            var result = CustomMapper.GetInstance().Map<List<PlayerModel>>(entity);
            return result;
        }
    }
}
