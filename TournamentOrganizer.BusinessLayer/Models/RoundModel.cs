using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class RoundModel : BaseModel
    {
        public RoundModel()
        {
            Matchs = new();
        }

        private int _roundNumber;
        public int RoundNumber
        {
            get { return _roundNumber; }
            set
            {
                _roundNumber = value;
                OnPropertyChanged(nameof(RoundNumber));
            }
        }
        public ObservableCollection<MatchModel> Matchs { get; set; }

        public ObservableCollection<ObservableCollection<IParticipant>> GetAllParticipantPairsInMatchs()
        {
            ObservableCollection<ObservableCollection<IParticipant>> playerPairs = new();
            for (int i = 0; i < Matchs.Count; i++)
            {
                playerPairs.Add(Matchs[i].Participants);
            }
            return playerPairs;
        }

        private ObservableCollection<IParticipant> GetSortedParticipantsByScore(TournamentModel tournament)
        {
            var sortedResults = tournament.ParticipantsResults;
            ObservableCollection<IParticipant> sortedParticipants = new();
            foreach (ParticipantTournamentResult item in sortedResults)
            {
                sortedParticipants.Add(item.Participant);
            }
            return sortedParticipants;
        }

        public void DistributeParticipants(TournamentModel tournament)
        {
            ObservableCollection<IParticipant> sortedPlayersByScore = GetSortedParticipantsByScore(tournament);
            ObservableCollection<ObservableCollection<IParticipant>> allTournamentPairs = tournament.GetAllPlayerPairsInTournament();

            while (sortedPlayersByScore.Count != 0)
            {
                MatchModel match = new MatchModel();
                
                int index = 1;
                for (int i = 0; i < allTournamentPairs.Count; i++)
                {
                    if (index == sortedPlayersByScore.Count)
                    {
                        foreach (IParticipant item in allTournamentPairs[allTournamentPairs.Count - 1])
                            sortedPlayersByScore.Add(item);

                        allTournamentPairs.RemoveAt(allTournamentPairs.Count - 1);
                        Matchs.RemoveAt(Matchs.Count - 1);
                        i = -1;
                        index = 1;
                    }
                    else if (allTournamentPairs[i].Contains(sortedPlayersByScore[0])
                        && allTournamentPairs[i].Contains(sortedPlayersByScore[index]))
                    {
                        i = -1;
                        index++;
                    }
                }
                match.Participants.Add(sortedPlayersByScore[0]);
                match.Participants.Add(sortedPlayersByScore[index]);
                Matchs.Add(match);
                sortedPlayersByScore.RemoveAt(0);
                sortedPlayersByScore.RemoveAt(index - 1);
                allTournamentPairs.Add(match.Participants);
            }
            SetNumbersOfMatchs(tournament);
        }

        public void SetNumbersOfMatchs(TournamentModel tournament)
        {
            for (int i = 0; i < Matchs.Count; i++)
            {
                Matchs[i].MatchNumber = i + 1;
            }
        }

        public bool CheckMatchesOnResolved()
        {
            foreach (var item in Matchs)
            {
                if (!item.MatchResolved)
                    return false;
            }
            return true;
        }

       
    }
}