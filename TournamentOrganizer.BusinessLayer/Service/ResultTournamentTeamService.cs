using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public class ResultTournamentTeamService
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

        public void SetTeamResultInRoundOfTournament(int newResult, int playerId, int numberRound, int tournamentId)
        {
            _resultTournamentTeamRepository.SetTeamResultInRoundOfTournament(newResult, playerId, numberRound, tournamentId);
        }

        public void SetMatchRoundInTournamentByTeamId(int tournamentId, int teamId, int numMatch, int numRound)
        {
            _resultTournamentTeamRepository.SetMatchRoundInTournamentByTeamId(tournamentId, teamId, numMatch, numRound);
        }

        public List<ResultTournamentTeamModel> GetTeamResultsInTournament(int teamId, int tournamentId)
        {
            var results = _resultTournamentTeamRepository.GetTeamsResultsInTournament(teamId, tournamentId);
            return CustomMapper.GetInstance().Map<List<ResultTournamentTeamModel>>(results);
        }

        public void InsertTeamIdRoundMatchTournament(int teamId, int round, int match, int tournament)
        {
            _resultTournamentTeamRepository.InsertTeamIdRoundMatchTournament(teamId, round, match, tournament);
        }

        public void CreateTournamentFromDataBase(TournamentModel tournament)
        {
            int tournamentId = tournament.Id;
            List<ResultTournamentTeamModel> data = GetDataOfTournament(tournamentId);
            if (data.Count == 0)
            {
                return;
            }

            foreach (var item in GetTeamsByTournamentId(tournamentId))
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
                        match.Participants.Add(instance.Team);
                        match.TeamsResults.Add(instance);
                    }
                    tournament.Rounds[i - 1].Matchs.Add(match);
                }
            }
            StartFillResultTeamsInTournament(tournament);
            if (tournament.NumberRounds <= tournament.Rounds.Count)
            {
                tournament.StartTournament();
                tournament.CloseTournament();
            }
        }

        public void StartFillResultTeamsInTournament(TournamentModel tournament)
        {
            foreach (var item in tournament.ParticipantsResults)
            {
                foreach (var result in GetTeamResultsInTournament(item.Participant.Id, tournament.Id))
                {
                    item.Score += (int)result.Result;
                }
            }
        }

        public void UpdateTeamInMatchRoundTournament(int teamId, int tournamentId, int numberRound, int numberMatch)
        {
            _resultTournamentTeamRepository.UpdateTeamInMatchRoundTournament(teamId, tournamentId, numberRound, numberMatch);
        }

        public void DeleteByTournamentRoundMatch(int tournamentId, int numberRound)
        {
            _resultTournamentTeamRepository.DeleteByTournamentRoundMatch(tournamentId, numberRound);
        }
    }
}
