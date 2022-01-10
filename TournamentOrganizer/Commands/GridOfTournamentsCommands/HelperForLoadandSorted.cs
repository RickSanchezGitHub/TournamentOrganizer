using System.Collections.Generic;
using System.Linq;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public static class HelperForLoadAndSorted
    {
        public static void SortResultInTournament(TournamentModel tournament,
            IResultTournamentPlayerService resultTournamentPlayerService,
            IResultTournamentTeamService resultTournamentTeamService)
        {
            tournament.ParticipantsResults.Clear();
            if (tournament.OnlyForTeams)
            {
                foreach (IParticipant item in tournament.Participants)
                {
                    ParticipantTournamentResult participantTournamentResult = new(item);
                    foreach (var results in resultTournamentTeamService.GetTeamResultsInTournament(item.Id, tournament.Id))
                    {
                        participantTournamentResult.Score += (int)results.Result;
                    }
                    tournament.ParticipantsResults.Add(participantTournamentResult);
                }
            }
            else
            {
                foreach (IParticipant item in tournament.Participants)
                {
                    ParticipantTournamentResult participantTournamentResult = new(item);
                    foreach (var results in resultTournamentPlayerService.GetPlayerResultsInTournament(item.Id, tournament.Id))
                    {
                        participantTournamentResult.Score += (int)results.Result;
                    }
                    tournament.ParticipantsResults.Add(participantTournamentResult);

                }
            }

            tournament.ParticipantsResults.OrderByDescending(item => item.Score);
        }


        public static void CreateTournamentFromDataBase(TournamentModel tournament, IResultTournamentPlayerService resultTournamentPlayerService)
        {
            int tournamentId = tournament.Id;
            List<ResultTournamentPlayerModel> data = resultTournamentPlayerService.GetDataOfTournament(tournament);
            if (data.Count == 0)
            {
                return;
            }

            foreach (var item in resultTournamentPlayerService.GetPlayersByTournamentId(tournament))
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
                var matchData = resultTournamentPlayerService.GetDataOfTournamentByRound(tournamentId, i);
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
                        match.ParticipantsResults.Add(instance);
                    }
                    tournament.Rounds[i - 1].Matchs.Add(match);
                }
            }
            StartFillResultPlayersInTournament(tournament, resultTournamentPlayerService);
            if (tournament.NumberRounds <= tournament.Rounds.Count)
            {
                tournament.StartTournament();
                tournament.CloseTournament();
            }
        }

        private static void StartFillResultPlayersInTournament(TournamentModel tournament, IResultTournamentPlayerService resultTournamentPlayerService)
        {
            foreach (var item in tournament.ParticipantsResults)
            {
                foreach (var result in resultTournamentPlayerService.GetPlayerResultsInTournament(item.Participant.Id, tournament.Id))
                {
                    item.Score += (int)result.Result;
                }
            }
        }

        public static void CreateTournamentFromDataBase(TournamentModel tournament, IResultTournamentTeamService resultTournamentTeamService)
        {
            int tournamentId = tournament.Id;
            List<ResultTournamentTeamModel> data = resultTournamentTeamService.GetDataOfTournament(tournamentId);
            if (data.Count == 0)
            {
                return;
            }

            foreach (var item in resultTournamentTeamService.GetTeamsByTournamentId(tournamentId))
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
                var matchData = resultTournamentTeamService.GetDataOfTournamentByRound(tournamentId, i);
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
                        match.ParticipantsResults.Add(instance);
                    }
                    tournament.Rounds[i - 1].Matchs.Add(match);
                }
            }
            StartFillResultTeamsInTournament(tournament, resultTournamentTeamService);
            if (tournament.NumberRounds <= tournament.Rounds.Count)
            {
                tournament.StartTournament();
                tournament.CloseTournament();
            }
        }

        private static void StartFillResultTeamsInTournament(TournamentModel tournament, IResultTournamentTeamService resultTournamentTeamService)
        {
            foreach (var item in tournament.ParticipantsResults)
            {
                foreach (var result in resultTournamentTeamService.GetTeamResultsInTournament(item.Participant.Id, tournament.Id))
                {
                    item.Score += (int)result.Result;
                }
            }
        }




    }
}
