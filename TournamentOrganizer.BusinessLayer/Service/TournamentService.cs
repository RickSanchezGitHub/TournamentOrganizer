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
        private readonly GameRepository _gameRepository;

        public TournamentService()
        {
            _tournamentRepository = new TournamentRepository();
            _gameRepository = new GameRepository();
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

        public int InsertTournament(TournamentModel tournament)
        {
            var tournamentModel = CustomMapper.GetInstance().Map<Tournament>(tournament);
            return _tournamentRepository.TournamentInsert(tournamentModel);
        }

        public List<GameModel> GetAllGames()
        {
            var games = _gameRepository.GameSelectAll();
            return CustomMapper.GetInstance().Map<List<GameModel>>(games);
        }
    }

}
