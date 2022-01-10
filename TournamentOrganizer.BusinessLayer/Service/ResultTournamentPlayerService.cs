using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public class ResultTournamentPlayerService : IResultTournamentPlayerService
    {
        private readonly ResultTournamentPlayerRepository _resultTournamentPlayerRepository;
        private readonly PlayerRepository _playerRepository;

        public ResultTournamentPlayerService()
        {
            _resultTournamentPlayerRepository = new();
            _playerRepository = new();
        }

        public List<PlayerModel> GetPlayersByTournamentId(TournamentModel tournament)
        {
            var players = _playerRepository.GetPlayersInTournament(tournament.Id);
            return CustomMapper.GetInstance().Map<List<PlayerModel>>(players);
        }

        public List<ResultTournamentPlayerModel> GetDataOfTournament(TournamentModel tournament)
        {
            var data = _resultTournamentPlayerRepository.GetDataOfTournament(tournament.Id);
            List<ResultTournamentPlayerModel> result = CustomMapper.GetInstance().Map<List<ResultTournamentPlayerModel>>(data);
            return result;
        }


        public List<ResultTournamentPlayerModel> GetDataOfTournamentByRound(int tournamentId, int numberRound)
        {
            var data = _resultTournamentPlayerRepository.GetPlayersResultsInTournamentRound(tournamentId, numberRound);
            return CustomMapper.GetInstance().Map<List<ResultTournamentPlayerModel>>(data);

        }

        public void SetPlayerResultInRoundOfTournament(int newResult, ResultTournamentPlayerModel resultTournamentPlayerModel)
        {
            var resultTournamentPlayer = CustomMapper.GetInstance().Map<ResultTournamentPlayer>(resultTournamentPlayerModel);
            _resultTournamentPlayerRepository.SetPlayerResultInRoundOfTournament(newResult, resultTournamentPlayer);
        }

        public int InsertPlayerIdRoundMatchTournament(ResultTournamentPlayerModel resultTournamentPlayerModel)
        {
            var resultTournamentPlayer = CustomMapper.GetInstance().Map<ResultTournamentPlayer>(resultTournamentPlayerModel);
            return _resultTournamentPlayerRepository.InsertPlayerIdRoundMatchTournament(resultTournamentPlayer);
        }

        public List<ResultTournamentPlayerModel> GetPlayerResultsInTournament(int playerId, int tournamentId)
        {
            var results = _resultTournamentPlayerRepository.GetPlayerResultsInTournament(playerId, tournamentId);
            return CustomMapper.GetInstance().Map<List<ResultTournamentPlayerModel>>(results);
        }
        public void DeleteByTournamentRound(int tournamentId, int numberRound)
        {
            _resultTournamentPlayerRepository.DeleteByTournamentRound(tournamentId, numberRound);
        }

        public void DeleteByPlayerIdAndTournamentId(int playerId, int tournamentId)
        {
            _resultTournamentPlayerRepository.DeleteByPlayerIdAndTournamentId(playerId, tournamentId);
        }

    }
}
