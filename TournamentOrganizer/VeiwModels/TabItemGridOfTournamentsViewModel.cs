﻿using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.DataLayer.Repositories;
using TournamentOrganizer.UI.Commands;
using TournamentOrganizer.UI.Commands.GridOfTournamentsCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemGridOfTournamentsViewModel : BaseViewModel
    {
        public ObservableCollection<TournamentModel> Tournaments { get; set; }
        public ObservableCollection<IParticipant> ParticipantsForRedistribution { get; set; }
        public ObservableCollection<ParticipantTournamentResult> ParticipantTournamentResults { get; set; }

        private ITournamentService _tournamentService;
        private IPlayerService _playerService;
        private ResultTournamentPlayerService _resultTournamentPlayerService;
        public TabItemGridOfTournamentsViewModel()
        {
            _tournamentService = new TournamentService();
            _playerService = new PlayerService();
            _resultTournamentPlayerService = new ResultTournamentPlayerService();
            TournamentSelect = new TournamentSelectCommand(this, _tournamentService);
            Tournaments = new ObservableCollection<TournamentModel>();
            CreateRound = new CreateRoundCommand(this);
            SetWinner = new SetWinnerCommand(this);
            SetDraw = new SetDrawCommand(this);
            BackFromResolveMatch = new BackFromResolveMatchCommand(this);
            ShowTournamentParticipants = new ShowTournamentParticipantsCommand(this);
            LoadTournaments = new LoadTournamentsCommand(this, _resultTournamentPlayerService, _playerService, _tournamentService);
            ResolveMatch = new ResolveMatchCommand(this);
            StartTournament = new StartTournamentCommand(this);
            RedistributeParticipants = new RedistributeParticipantsCommand(this);
            SaveRedistribute = new SaveRedistributeCommand(this);
            ParticipantsForRedistribution = new();
            SelctedMatchInTreeView = new();
            ParticipantTournamentResults = new();
            VisibilityStackPanelMatchResolve = Visibility.Collapsed;
            VisibilityButtonShowTournamentParticipants = Visibility.Collapsed;
            VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
            VisibilityStackPanelRedistributeParticipants = Visibility.Collapsed;
            VisibilityButtonForStartTournament = Visibility.Hidden;
            ShowParticipantsTournamentResult = "Показать участников турнира";
            //InitialData();
            //Command = new RoutedCommand("Command", typeof(Button));
        }

        private TournamentModel _selectedTournament;
        public TournamentModel SelectedTournament
        {
            get { return _selectedTournament; }
            set
            {
                _selectedTournament = value;
                OnPropertyChanged(nameof(SelectedTournament));
                if (_selectedTournament != null)
                    VisibilityButtonShowTournamentParticipants = Visibility.Visible;

                if (_selectedTournament.StartedTournament == false)
                {
                    VisibilityButtonForStartTournament = Visibility.Visible;
                }
                else
                {
                    VisibilityButtonForStartTournament = Visibility.Hidden;
                }
                if (_selectedTournament.OnlyForTeams)
                {
                    PlayersOrTeams = "Name";
                }
                else
                {
                    PlayersOrTeams = "NickName";
                }

                
            }
        }

        private string _playersOrTeams;
        public string PlayersOrTeams
        {
            get { return _playersOrTeams; }
            set
            {
                _playersOrTeams = value;
                OnPropertyChanged(nameof(PlayersOrTeams));
            }
        }

        private string _showParticipantsTournamentResult;
        public string ShowParticipantsTournamentResult
        {
            get { return _showParticipantsTournamentResult; }
            set
            {
                _showParticipantsTournamentResult = value;
                OnPropertyChanged(nameof(ShowParticipantsTournamentResult));
            }
        }

        private MatchModel _selctedMatchInTreeView;
        public MatchModel SelctedMatchInTreeView
        {
            get { return _selctedMatchInTreeView; }
            set
            {
                _selctedMatchInTreeView = value;
                OnPropertyChanged(nameof(SelctedMatchInTreeView));

            }
        }

        private RoundModel _roundForRedistribute;
        public RoundModel RoundForRedistribute
        {
            get { return _roundForRedistribute; }
            set
            {
                _roundForRedistribute = value;
                OnPropertyChanged(nameof(RoundForRedistribute));

            }
        }
        private RoundModel _newRound;
        public RoundModel NewRound
        {
            get { return _newRound; }
            set
            {
                _newRound = value;
                OnPropertyChanged(nameof(NewRound));

            }
        }
        private IParticipant _selctedPlayerInComboBox;
        public IParticipant SelctedPlayerInComboBox
        {
            get { return _selctedPlayerInComboBox; }
            set
            {
                _selctedPlayerInComboBox = value;
                OnPropertyChanged(nameof(SelctedPlayerInComboBox));

            }
        }

        private Visibility _visibilityStackPanelRedistributeParticipants;
        public Visibility VisibilityStackPanelRedistributeParticipants
        {
            get { return _visibilityStackPanelRedistributeParticipants; }
            set
            {
                _visibilityStackPanelRedistributeParticipants = value;
                OnPropertyChanged(nameof(VisibilityStackPanelRedistributeParticipants));
            }
        }

        private Visibility _visibilityStackPanelMatchResolve;
        public Visibility VisibilityStackPanelMatchResolve
        {
            get { return _visibilityStackPanelMatchResolve; }
            set
            {
                _visibilityStackPanelMatchResolve = value;
                OnPropertyChanged(nameof(VisibilityStackPanelMatchResolve));
            }
        }
        private Visibility _visibilityButtonShowTournamentParticipants;
        public Visibility VisibilityButtonShowTournamentParticipants
        {
            get { return _visibilityButtonShowTournamentParticipants; }
            set
            {
                _visibilityButtonShowTournamentParticipants = value;
                OnPropertyChanged(nameof(VisibilityButtonShowTournamentParticipants));
            }
        }

        private Visibility _visibilityDataGridShowTournamentParticipants;
        public Visibility VisibilityDataGridShowTournamentParticipants
        {
            get { return _visibilityDataGridShowTournamentParticipants; }
            set
            {
                _visibilityDataGridShowTournamentParticipants = value;
                OnPropertyChanged(nameof(VisibilityDataGridShowTournamentParticipants));
            }
        }

        private Visibility _visibilityButtonForStartTournament;
        public Visibility VisibilityButtonForStartTournament
        {
            get { return _visibilityButtonForStartTournament; }
            set
            {
                _visibilityButtonForStartTournament = value;
                OnPropertyChanged(nameof(VisibilityButtonForStartTournament));
            }
        }

        private Button _selectedButton;
        public Button SelectedButton
        {
            get { return _selectedButton; }
            set
            {
                _selectedButton = value;
                OnPropertyChanged(nameof(SelectedButton));
            }
        }

        public ICommand TournamentSelect { get; set; }
        public ICommand CreateRound { get; set; }
        public ICommand SetWinner { get; set; }
        public ICommand SetDraw { get; set; }
        public ICommand BackFromResolveMatch { get; set; }
        public ICommand ShowTournamentParticipants { get; set; }
        public ICommand LoadTournaments { get;set; }
        public ICommand ResolveMatch { get; set; }
        public ICommand StartTournament { get; set; }
        public ICommand RedistributeParticipants { get; set; }
        public ICommand SaveRedistribute { get; set; }

        //public RoutedCommand Command { get; set; }

        //public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var button = (Button)sender;
        //    var data = button.DataContext;
        //    SelctedMatchInTreeView = (MatchModel)data;
        //    VisibilityStackPanelMatchResolve = Visibility.Visible;
        //    VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
        //}

        //private void InitialData()
        //{
        //    GameService game = new GameService();
        //    PlayerService playerService = new PlayerService();

        //    TournamentModel tour = new TournamentModel
        //    {
        //        Name = "Experience tour",
        //        Game = game.GameSelectById(1),
        //        StartDate = DateTime.Now.AddDays(-10),
        //        CloseDate = DateTime.Now
        //    };
        //    var listPlayers = playerService.GetAll();

        //    foreach (PlayerModel item in listPlayers)
        //    {
        //        tour.Participants.Add(item);
        //        //tour.ParticipantsResults.Add(new ParticipantTournamentResult(item));
        //    }

        //    tour.StartTournament();
        //    Tournaments.Add(tour);
        //}
    }
}
