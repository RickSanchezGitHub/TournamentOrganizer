﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class RoundModel : INotifyPropertyChanged
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void DistributeParticipantsInFirstRound(List<PlayerModel> participants)
        {
            Matchs = new ObservableCollection<MatchModel>();
            //participantsResults.OrderByDescending(item => item.Score); - в команды
            if (RoundNumber == 1)
            {
                int numberHalfParticipants = participants.Count / 2;
                for (int i = 0; i < numberHalfParticipants; i++)
                {
                    var match = new MatchModel();
                    match.Participants = new ObservableCollection<PlayerModel>();
                    match.Participants.Add(participants[i]);
                    match.Participants.Add(participants[i + numberHalfParticipants]);
                    Matchs.Add(match);
                }
            }
            else
            {
                return;
            }
        }

        #region Comments
        /*
        public void DistributeParticipants(List<PlayerModel> participants,
            TournamentModel tournament)
        {
            List<PlayerModel> sortedParticipantsByScore = participants;

            List<List<PlayerModel>> playersPairs = tournament.GetAllPlayerPairsInTournament();
            var s = tournament.GetAllPlayerPairsInTournament();

            while (sortedParticipantsByScore.Count > 0)
            {
                MatchModel match = new MatchModel();
                match.Participants = new();
                int g = 1;
                match.Participants.Add(sortedParticipantsByScore[0]);

                for (int j = 0; j < s.Count; j++)
                {
                    match.Participants.Add(sortedParticipantsByScore[g]);
                    if (1 == match.Participants.Intersect(s[j]).Count())
                    {
                        sortedParticipantsByScore.Remove(sortedParticipantsByScore[0]);
                        if (sortedParticipantsByScore.Count != 0)
                            sortedParticipantsByScore.Remove(sortedParticipantsByScore[g]);

                        s.Remove(s[j]);
                        g = 1;
                        break;
                    }
                    else
                    {
                        match.Participants.Remove(sortedParticipantsByScore[g]);
                        g++;
                    }
                }
                Matchs.Add(match);
            }

        }
        */
        #endregion

        public ObservableCollection<ObservableCollection<PlayerModel>> GetAllPlayerPairsInMatchs()
        {
            ObservableCollection<ObservableCollection<PlayerModel>> playerPairs = new();
            for (int i = 0; i < Matchs.Count; i++)
            {
                playerPairs.Add(Matchs[i].Participants);
            }
            return playerPairs;
        }

        private ObservableCollection<PlayerModel> GetTournamentPlayersAndOrderByDescending(TournamentModel tournament)
        {
            var sortedResults = tournament.ParticipantsResults.OrderByDescending(item => item.Score);
            ObservableCollection<PlayerModel> sortedParticipants = new();
            foreach (ParticipantTournamentResult item in sortedResults)
            {
                sortedParticipants.Add(item.Participant);
            }
            return sortedParticipants;
        }

        public void DistributeParticipants(ObservableCollection<PlayerModel> participants,
            TournamentModel tournament)
        {
            ObservableCollection<PlayerModel> sortedPlayersByScore = GetTournamentPlayersAndOrderByDescending(tournament);
            ObservableCollection<ObservableCollection<PlayerModel>> allTournamentPairs = tournament.GetAllPlayerPairsInTournament();

            while (sortedPlayersByScore.Count != 0)
            {
                MatchModel match = new MatchModel();
                match.Participants = new();

                int index = 1;
                for (int i = 0; i < allTournamentPairs.Count; i++)
                {
                    if (index == sortedPlayersByScore.Count)
                    {
                        foreach (PlayerModel item in allTournamentPairs[allTournamentPairs.Count - 1])
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

        }
    }
}

/*
 void Circle(List<int> listIntov, List<List<int>> pairs)
            {
                var copy = CreateCopy(listIntov);

                while (copy.Count != 0)
                {
                    List<int> newPair = new();
                    int index = 1;

                    for (int i = 0; i < pairs.Count; i++)
                    {
                        //если index уже дошёл до размера copy, но цикл не завершился, значит из
                        //имеющихся в copy данных невозможно составить такую турнирную пару, которой 
                        //ещё не было бы. Поэтому необходимо стереть из pairs последнюю пару и её
                        //значения добавить обратно в copy
                        if (index == copy.Count)
                        {
                            foreach (int item in pairs[pairs.Count - 1])
                                copy.Add(item);

                            pairs.RemoveAt(pairs.Count - 1);
                            i = -1;
                            index = 1;

                        }
                        //если итая пара содержит оба элемента, то нет смысла смотреть дальше 
                        //можно обнулить счётчик i и увеличить index
                        else if ((pairs[i].Contains(copy[0]) && pairs[i].Contains(copy[index])))
                        {
                            i = -1;
                            index++;
                        }
                    }
                    newPair.Add(copy[0]);
                    newPair.Add(copy[index]);
                    copy.Remove(copy[0]);
                    copy.Remove(copy[index - 1]);
                    pairs.Add(newPair);
                }
            }
 */