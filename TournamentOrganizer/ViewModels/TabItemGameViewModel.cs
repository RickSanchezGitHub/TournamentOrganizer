using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.Commands;

namespace TournamentOrganizer.UI.ViewModels
{
    public class TabItemGameViewModel : BaseViewModel
    {
        private GameService _gameService;
        public TabItemGameViewModel()
        {
            _gameService = new GameService();
            Games = new ObservableCollection<GameModel>(_gameService.GetAllGames());
            StateDataGrid = true;
            IsEnabledButtonAdd = true;
            TextBoxAddGameNameText = string.Empty;
            SelectedGame = null;
            IsEnabledButtonCancel = false;
            VisibilityButtonSave = Visibility.Hidden;
            DeleteGameCommand = new DeleteGameCommand(this, _gameService);
            AddGameCommand = new AddGameCommand(this, _gameService);
            CancelGameCommand = new CancelGameCommand(this);
            EditGameCommand = new EditGameCommand(this, _gameService);
            SaveGameCommand = new SaveGameCommand(this, _gameService);

        }
        private ObservableCollection<GameModel> _games;
        public ObservableCollection<GameModel> Games
        {
            get { return _games; }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        private bool _stateDataGrid;
        public bool StateDataGrid
        {
            get { return _stateDataGrid; }
            set
            {
                _stateDataGrid = value;
                OnPropertyChanged(nameof(StateDataGrid));
            }
        }

        private string _buttonAddEditContent;
        public string ButtonAddEditContent
        {
            get { return _buttonAddEditContent; }
            set
            {
                _buttonAddEditContent = value;
                OnPropertyChanged(nameof(ButtonAddEditContent));
            }
        }

        private string _textBoxAddGameNameText;
        public string TextBoxAddGameNameText
        {
            get { return _textBoxAddGameNameText; }
            set
            {
                _textBoxAddGameNameText = value;
                OnPropertyChanged(nameof(TextBoxAddGameNameText));
            }
        }

        private GameModel _selectedGame;
        public GameModel SelectedGame
        {
            get { return _selectedGame; }
            set
            {
                _selectedGame = value;
                OnPropertyChanged(nameof(SelectedGame));
            }
        }

        private bool _isEnabledButtonCancel;
        public bool IsEnabledButtonCancel
        {
            get { return _isEnabledButtonCancel; }
            set
            {
                _isEnabledButtonCancel = value;
                OnPropertyChanged(nameof(IsEnabledButtonCancel));
                if (IsEnabledButtonCancel)
                {
                    VisibilityButtonCancel = Visibility.Visible;
                }
                else
                {
                    VisibilityButtonCancel = Visibility.Hidden;
                }
            }
        }

        private Visibility _visibilityButtonCancel;

        public Visibility VisibilityButtonCancel
        {
            get { return _visibilityButtonCancel; }
            set
            {
                _visibilityButtonCancel = value;
                OnPropertyChanged(nameof(VisibilityButtonCancel));
            }
        }
        private bool _isEnabledButtonSave;
        public bool IsEnabledButtonSave
        {
            get { return _isEnabledButtonSave; }
            set
            {
                _isEnabledButtonSave = value;
                OnPropertyChanged(nameof(IsEnabledButtonSave));
                if (IsEnabledButtonSave)
                {
                    VisibilityButtonSave = Visibility.Visible;
                }
                else
                {
                    VisibilityButtonSave = Visibility.Hidden;
                }
            }
        }

        private Visibility _visibilityButtonSave;

        public Visibility VisibilityButtonSave
        {
            get { return _visibilityButtonSave; }
            set
            {
                _visibilityButtonSave = value;
                OnPropertyChanged(nameof(VisibilityButtonSave));
            }
        }
        private bool _isEnabledButtonAdd;
        public bool IsEnabledButtonAdd
        {
            get { return _isEnabledButtonAdd; }
            set
            {
                _isEnabledButtonAdd = value;
                OnPropertyChanged(nameof(IsEnabledButtonAdd));
                if (IsEnabledButtonAdd)
                {
                    VisibilityButtonAdd = Visibility.Visible;
                }
                else
                {
                    VisibilityButtonAdd = Visibility.Hidden;
                }
            }
        }

        private Visibility _visibilityButtonAdd;

        public Visibility VisibilityButtonAdd
        {
            get { return _visibilityButtonAdd; }
            set
            {
                _visibilityButtonAdd = value;
                OnPropertyChanged(nameof(VisibilityButtonAdd));
            }
        }

        public ICommand DeleteGameCommand { get; set; }

        public ICommand AddGameCommand { get; set; }
        public ICommand CancelGameCommand { get; set; }
        public ICommand EditGameCommand { get; set; }

        public ICommand SaveGameCommand { get; set; }

    }

}
