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
    public class ResultTournamentTeamService : IResultTournamentTeamService
    {
        private readonly ResultTournamentTeamRepository _resultTournamentTeamRepository;

        public ResultTournamentTeamService()
        {
            _resultTournamentTeamRepository = new();
        }

        public List<TeamModel> GetTeamsByTournamentId(int tournamentId)
        {
            var teams = _resultTournamentTeamRepository.GetTeamsInTournament(tournamentId);
            return CustomMapper.GetInstance().Map<List<TeamModel>>(teams);
        }

        public List<ResultTournamentTeamModel> GetDataOfTournament(int tournamentId)
        {
            var data = _resultTournamentTeamRepository.GetDataOfTournament(tournamentId);
            List<ResultTournamentTeamModel> result = CustomMapper.GetInstance().Map<List<ResultTournamentTeamModel>>(data);
            return result;
        }

        public List<ResultTournamentTeamModel> GetDataOfTournamentByRound(int tournamentId, int numberRound)
        {
            var data = _resultTournamentTeamRepository.GetTeamsResultsInTournamentRound(tournamentId, numberRound);
            return CustomMapper.GetInstance().Map<List<ResultTournamentTeamModel>>(data);

        }

        public void SetTeamResultInRoundOfTournament(ResultTournamentTeamModel resultTournamentTeamModel, int newResult)
        {
            var resultTournamentTeam = CustomMapper.GetInstance().Map<ResultTournamentTeam>(resultTournamentTeamModel);
            _resultTournamentTeamRepository.SetTeamResultInRoundOfTournament(resultTournamentTeam, newResult);
        }

        public List<ResultTournamentTeamModel> GetTeamResultsInTournament(int teamId, int tournamentId)
        {
            var results = _resultTournamentTeamRepository.GetTeamsResultsInTournament(teamId, tournamentId);
            return CustomMapper.GetInstance().Map<List<ResultTournamentTeamModel>>(results);
        }

        public int InsertTeamIdRoundMatchTournament(ResultTournamentTeamModel resultTournamentTeamModel)
        {
            var resultTournamentTeam = CustomMapper.GetInstance().Map<ResultTournamentTeam>(resultTournamentTeamModel);
            return _resultTournamentTeamRepository.InsertTeamIdRoundMatchTournament(resultTournamentTeam);
        }

        public void DeleteByTournamentRound(int tournamentId, int numberRound)
        {
            _resultTournamentTeamRepository.DeleteByTournamentRound(tournamentId, numberRound);
        }

        public void DeleteByTeamIdAndTournamentId(int teamId, int tournamentId)
        {
            _resultTournamentTeamRepository.DeleteByTeamIdAndTournamentId(teamId, tournamentId);
        }
    }
}
