using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public class ResultTournamentPlayerService
    {
        private readonly ResultTournamentPlayerRepository _resultTournamentPlayerRepository;
        public ResultTournamentPlayerService()
        {
            _resultTournamentPlayerRepository = new ResultTournamentPlayerRepository();
        }

        public List<ResultTournamentPlayerModel> GetPlayerResultsInAllTournaments(int playerId)
        {
            var tournaments = _resultTournamentPlayerRepository.GetPlayerResultsInAllTournaments(playerId);
            return CustomMapper.GetInstance().Map<List<ResultTournamentPlayerModel>>(tournaments);
        }

        public void DeleteTournament(int id)
        {
            //_resultTournamentPlayerRepository.TournamentDeleteById(id);
        }

    }
}
