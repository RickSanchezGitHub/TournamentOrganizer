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
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;

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
            ButtonAddEditContent = "Добавить";
            TextBoxAddGameNameText = string.Empty;
            SelectedGame = null;
            StateButtonCancel = false;
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

        private bool _stateButtonCancel;
        public bool StateButtonCancel
        {
            get { return _stateButtonCancel; }
            set
            {
                _stateButtonCancel = value;
                OnPropertyChanged(nameof(StateButtonCancel));
                if (StateButtonCancel)
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

    }
}
