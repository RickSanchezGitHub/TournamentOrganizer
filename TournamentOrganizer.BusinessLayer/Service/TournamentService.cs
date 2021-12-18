using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;
        public TournamentService()
        {
            _tournamentRepository = new TournamentRepository();
        }

        public List<TournamentModel> GetAllTournaments()
        {
            var tournaments = _tournamentRepository.TournamentSelectAll();
            return CustomMaoper.GetInstance().Map<List<TournamentModel>>(tournaments);
        }
    }
}
