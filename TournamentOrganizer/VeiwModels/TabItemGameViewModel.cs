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

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemGameViewModel : BaseViewModel
    {
        public GameService GameService;
        public TabItemGameViewModel()
        {
            GameService = new GameService();
            Games = new ObservableCollection<GameModel>(GameService.GetAllGames());
            StateDataGrid = true;
            IsEnabledButtonAdd = true;
            TextBoxAddGameNameText = string.Empty;
            SelectedGame = null;
            IsEnabledButtonCancel = false;
            VisibilityButtonSave = Visibility.Hidden;
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
        private ICommand _deleteGameCommand;
        public ICommand DeleteGameCommand
        {
            get
            {
                if (_deleteGameCommand == null)
                {
                    _deleteGameCommand = new DeleteGameCommand(this);
                }
                return _deleteGameCommand;
            }
        }
        private ICommand _addGameCommand;
        public ICommand AddGameCommand
        {
            get
            {
                if (_addGameCommand == null)
                {
                    _addGameCommand = new AddGameCommand(this);
                }
                return _addGameCommand;
            }
        }
        private ICommand _cancelGameCommand;
        public ICommand CancelGameCommand
        {
            get
            {
                if (_cancelGameCommand == null)
                {
                    _cancelGameCommand = new CancelGameCommand(this);
                }
                return _cancelGameCommand;
            }
        }
        private ICommand _editGameCommand;
        public  ICommand EditGameCommand
        {
            get
            {
                if (_editGameCommand == null)
                {
                    _editGameCommand = new EditGameCommand(this);
                }
                return _editGameCommand;
            }
        }
        private ICommand _saveGameCommand;
        public ICommand SaveGameCommand
        {
            get
            {
                if (_saveGameCommand == null)
                {
                    _saveGameCommand = new SaveGameCommand(this);
                }
                return _saveGameCommand;
            }
        }
    }

}
