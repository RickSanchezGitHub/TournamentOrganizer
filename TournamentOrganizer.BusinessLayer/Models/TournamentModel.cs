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
    public class TournamentModel : INotifyPropertyChanged
    {
        #region NikitaSergeevich
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime? _closeDate;
        public DateTime? CloseDate
        {
            get { return _closeDate; }
            set
            {
                _closeDate = value;
                OnPropertyChanged(nameof(CloseDate));
            }
        }

        private GameModel _game;
        public GameModel Game
        {
            get { return _game; }
            set
            {
                _game = value;
                OnPropertyChanged(nameof(Game));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        public TournamentModel(int numberParticipantsInMatch = 2)
        {
            NumberParticipantsInMatch = numberParticipantsInMatch;
            Rounds = new ObservableCollection<RoundModel>();
            Participants = new();
            ParticipantsResults = new();
            ParticipantsResultsInMatchs = new();
            _closeTournament = false;
            _startedTournament = false;

        }

        private bool _closeTournament;
        private bool _startedTournament;
        public ObservableCollection<ParticipantTournamentResult> ParticipantsResults { get; set; }

        public ObservableCollection<ResultTournamentParticipantModel> ParticipantsResultsInMatchs { get; set; }
        public ObservableCollection<IParticipant> Participants { get; set; }
        public ObservableCollection<RoundModel> Rounds { get; private set; }
        public int NumberParticipantsInMatch { get; private set; }//2

        public int NumberRounds { get; set; }
        private void SetNumberRounds()
        {
            NumberRounds = (int)Math.Log(Participants.Count, NumberParticipantsInMatch);
        }

        public void SetParticipantsResults()
        {
            foreach (IParticipant participant in Participants)
            {
                int score = ParticipantsResultsInMatchs.Where(item => item.Participant == participant).Sum(item => item.Result);
                ParticipantsResults.First(item => item.Participant == participant).Score = score;
            }
        }

        public bool CreateRound()
        {
            //или проверки в отдельный метод
            bool lastRoundIsResolved = Rounds.Count == 0 || Rounds.Last<RoundModel>().CheckMatchesOnResolved();
            if (NumberRounds > Rounds.Count && _startedTournament && lastRoundIsResolved)
            {
                int numberRound = Rounds.Count + 1;
                RoundModel newRound = new RoundModel { RoundNumber = numberRound };
                newRound.DistributeParticipants(Participants, this);
                Rounds.Add(newRound);
                return true;
            }
            return false;
        }

        public ObservableCollection<ObservableCollection<IParticipant>> GetAllPlayerPairsInTournament()
        {
            ObservableCollection<ObservableCollection<IParticipant>> playerPairs = new();
            for (int i = 0; i < Rounds.Count; i++)
            {
                foreach (var item in Rounds[i].GetAllPlayerPairsInMatchs())
                {
                    playerPairs.Add(item);
                }
            }
            return playerPairs;
        }

        public void CloseTournament()
        {
            _closeTournament = true;
        }

        public void StartTournament()
        {
            _startedTournament = true;
            SetNumberRounds();
        }

        public RoundModel GetRoundByMatch(MatchModel match)
        {
            for (int i = 0; i < Rounds.Count; i++)
            {
                if (Rounds[i].Matchs.Contains(match))
                {
                    return Rounds[i];
                }
            }
            return null;
        }
    }
}
