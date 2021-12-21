﻿using System;
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
    public class TeamService
    {
        private readonly TeamRepository _teamRepository;
        public TeamService()
        {
            _teamRepository = new TeamRepository();
        }
        public int Insert(TeamModel team)
        {
            var entity = CustomMapper.GetInstance().Map<TeamModel, Team>(team);
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
            var result = CustomMapper.GetInstance().Map<List<Team>,List<TeamModel>> (entity);
            return result;
        }
        public TeamModel GetById(int id)
        {
            var entity = _teamRepository.GetById(id);
            var result = CustomMapper.GetInstance().Map<Team, TeamModel>(entity);
            return result;
        }
    }
}
