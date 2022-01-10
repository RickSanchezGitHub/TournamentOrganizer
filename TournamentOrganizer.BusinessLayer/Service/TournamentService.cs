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
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IResultTournamentPlayerRepository _resultTournamentPlayerRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IResultTournamentTeamRepository _resultTournamentTeamRepository;

        public TournamentService()
        {
            _tournamentRepository = new TournamentRepository();
            _gameRepository = new GameRepository();
            _resultTournamentPlayerRepository = new ResultTournamentPlayerRepository();
            _playerRepository = new PlayerRepository();
            _teamRepository = new TeamRepository();
            _resultTournamentTeamRepository = new ResultTournamentTeamRepository();
        }

        public TournamentService(ITournamentRepository tournamentRepository, IGameRepository gameRepository, IResultTournamentPlayerRepository resultTournamentPlayerRepository)
        {
            _tournamentRepository = tournamentRepository;
            _gameRepository = gameRepository;
            _resultTournamentPlayerRepository = resultTournamentPlayerRepository;
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

        public List<TeamModel> GetTeamsInTournament(int tournamentId)
        {
            var resultTournamentTeams = _resultTournamentTeamRepository.GetTeamsInTournament(tournamentId);
            return CustomMapper.GetInstance().Map<List<TeamModel>>(resultTournamentTeams);
        }

        public void DeletePlayerFromTournament(int playerId, int tournamentId)
        {
            _resultTournamentPlayerRepository.DeleteByTournament(playerId, tournamentId);
        }
        public void DeleteTeamFromTournament(int teamId, int tournamentId)
        {
            _resultTournamentTeamRepository.DeleteByTournament(tournamentId, teamId);
        }

        public int AddPalyerToTournament(PlayerModel player, int tournamentId)
        {
            var playerModel = CustomMapper.GetInstance().Map<Player>(player);
            return _resultTournamentPlayerRepository.AddPlayerToTournament(playerModel, tournamentId);
        }

        public int AddTeamToTournament(TeamModel team, int tournamentId)
        {
            var teamModel = CustomMapper.GetInstance().Map<Team>(team);
            return _resultTournamentTeamRepository.AddTeamToTournament(teamModel, tournamentId);
        }


        public List<PlayerModel> GetAllPlayers()
        {
            var players = _playerRepository.GetAll();
            return CustomMapper.GetInstance().Map<List<PlayerModel>>(players);
        }

        public List<TeamModel> GetAllTeams()
        {
            var teams = _teamRepository.GetAll();
            return CustomMapper.GetInstance().Map<List<TeamModel>>(teams);
        }

    }

}
