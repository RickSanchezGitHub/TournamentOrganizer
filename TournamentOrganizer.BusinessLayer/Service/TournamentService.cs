using System.Collections.Generic;
using TournamentOrganaizer.DataLayer.Entities;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly TournamentRepository _tournamentRepository;
        private readonly GameRepository _gameRepository;
        private readonly ResultTournamentPlayerRepository _resultTournamentPlayerRepository;

        public TournamentService()
        {
            _tournamentRepository = new TournamentRepository();
            _gameRepository = new GameRepository();
            _resultTournamentPlayerRepository = new ResultTournamentPlayerRepository();
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

        public List<PlayerModel> GetPlayersInTournament(int tournamentId)
        {
            var resultTournamentPlayers = _resultTournamentPlayerRepository.GetPlayersInTournamentsByTournamentId(tournamentId);
            return CustomMapper.GetInstance().Map<List<PlayerModel>>(resultTournamentPlayers);
        }

        public void DeletePlayerFromTournament(int playerId, int tournamentId)
        {
            _resultTournamentPlayerRepository.DeleteByTournament(playerId, tournamentId);
        }
        public int AddPalyerToTournament(PlayerModel player, int tournamentId)
        {
            var playerModel = CustomMapper.GetInstance().Map<Player>(player);
            return _resultTournamentPlayerRepository.AddPlayerToTournament(playerModel, tournamentId);
        }
    }

}
