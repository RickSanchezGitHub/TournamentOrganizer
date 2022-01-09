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
    public class ResultTournamentPlayerService
    {
        private readonly ResultTournamentPlayerRepository _resultTournamentPlayerRepository;
        private readonly PlayerService _playerService;

        public ResultTournamentPlayerService()
        {
            _resultTournamentPlayerRepository = new();
            _playerService = new();
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

        public int SetPlayerResultInRoundOfTournament(int newResult, int playerId, int numberRound, int tournamentId)
        {
            return _resultTournamentPlayerRepository.SetPlayerResultInRoundOfTournament(newResult, playerId, numberRound, tournamentId);
        }

        public void InsertPlayerIdRoundMatchTournament(int playerId, int round, int match, int tournament)
        {
            _resultTournamentPlayerRepository.InsertPlayerIdRoundMatchTournament(playerId, round, match, tournament);
        }


        public void SetMatchRoundByPlayerTournament(int tournamentId, int playerId, int numMatch, int numRound)
        {
            _resultTournamentPlayerRepository.SetMatchRoundByPlayerTournament(tournamentId, playerId, numMatch, numRound);
        }


        public List<ResultTournamentPlayerModel> GetPlayerResultsInTournament(int playerId, int tournamentId)
        {
            var results = _resultTournamentPlayerRepository.GetPlayerResultsInTournament(playerId, tournamentId);
            return CustomMapper.GetInstance().Map<List<ResultTournamentPlayerModel>>(results);
        }

        public void CreateTournamentFromDataBase(TournamentModel tournament)
        {
            int tournamentId = tournament.Id;
            List<ResultTournamentPlayerModel> data = GetDataOfTournament(tournament);
            if (data.Count == 0)
            {
                return;
            }
            
            foreach (var item in _playerService.GetPlayersByTournamentId(tournament))
            {
                tournament.Participants.Add(item);
                tournament.ParticipantsResults.Add(new ParticipantTournamentResult(item));
            }
            tournament.SetNumberRounds();
            if (data.Any(item => item.NumberRound == 0))
                return;

            tournament.StartTournament();
            foreach (var item in data)
                tournament.ParticipantsResultsInMatchs.Add(item);

            int? maxRound = data.Max(item => item.NumberRound);
           
            for (int i = 1; i <= maxRound; i++)
            {
                tournament.Rounds.Add(new RoundModel { RoundNumber = i });
                var matchData = GetDataOfTournamentByRound(tournamentId, i);
                int? maxMatch = matchData.Max(item => item.NumberMatch);
                for (int j = 1; j <= maxMatch; j++)
                {
                    MatchModel match = new MatchModel { MatchNumber = j };
                    if (matchData.Where(item => item.NumberMatch == j).All(res => res.Result == 0))
                    {
                        match.MatchResolved = false;
                    }
                    else
                        match.MatchResolved = true;

                    foreach (var instance in matchData.Where(el => el.NumberMatch == j))
                    {
                        match.Participants.Add(instance.Player);
                        match.PlayersResults.Add(instance);
                    }
                    tournament.Rounds[i - 1].Matchs.Add(match);
                }
            }
            StartFillResultPlayersInTournament(tournament);
            if (tournament.NumberRounds <= tournament.Rounds.Count)
            {
                tournament.StartTournament();
                tournament.CloseTournament();
            }
        }

        public void StartFillResultPlayersInTournament(TournamentModel tournament)
        {
            foreach (var item in tournament.ParticipantsResults)
            {
                foreach (var result in GetPlayerResultsInTournament(item.Participant.Id, tournament.Id))
                {
                    item.Score += (int)result.Result;
                }
            }
        }

    }
}
