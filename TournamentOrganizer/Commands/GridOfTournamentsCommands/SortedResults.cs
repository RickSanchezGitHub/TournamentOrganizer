using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;

namespace TournamentOrganizer.UI.Commands.GridOfTournamentsCommands
{
    public static class SortedResults
    {
        public static void SortResultInTournament(TournamentModel tournament, 
            ResultTournamentPlayerService resultTournamentPlayerService,
            ResultTournamentTeamService resultTournamentTeamService)
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
    }
}
