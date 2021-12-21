using System.Collections.Generic;
using TournamentOrganaizer.DataLayer.Entities;
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
            return CustomMapper.GetInstance().Map<List<TournamentModel>>(tournaments);
        }

        public void DeleteTournament(int id)
        {
            _tournamentRepository.TournamentDeleteById(id);
        }

        public void UpdateTournament(TournamentModel tournament)
        {
            var tournamentModel = CustomMapper.GetInstance().Map<Tournament>(tournament);
            _tournamentRepository.TournamentUpdateById(tournamentModel);
        }

        public void InsertTournament(TournamentModel tournament)
        {
            var tournamentModel = CustomMapper.GetInstance().Map<Tournament>(tournament);
            _tournamentRepository.TournamentInsert(tournamentModel);
        }

    }

}
