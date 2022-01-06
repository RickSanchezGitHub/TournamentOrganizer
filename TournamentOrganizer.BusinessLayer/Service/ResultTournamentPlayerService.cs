using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public class ResultTournamentPlayerService
    {
        private readonly ResultTournamentTeamRepository _resultTournamentTeamRepository;
        private readonly ResultTournamentPlayerRepository _resultTournamentPlayerRepository;
        private readonly PlayerService _playerService;

        public ResultTournamentPlayerService()
        {
            _resultTournamentTeamRepository = new();
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
                    if (matchData.First(item => item.NumberMatch == j).Result == null)
                        match.MatchResolved = false;
                    else
                        match.MatchResolved = true;

                    foreach (var instance in matchData.Where(el => el.NumberMatch == j))
                        match.Participants.Add(instance.Player);

                    tournament.Rounds[i - 1].Matchs.Add(match);
                }
            }
            tournament.SetParticipantsResults();
            if (tournament.NumberRounds >= tournament.Rounds.Count)
            {
                tournament.StartTournament();
                tournament.CloseTournament();
            }
        }

    }
}
