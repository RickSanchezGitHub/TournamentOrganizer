using Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Interaction logic for TabItemTournament.xaml
    /// </summary>
    public partial class TabItemTournament : TabItem
    {
        private const double ColumnVisibilityOn = 40;
        private const double ColumnVisibilityOff = 0;
        private readonly TournamentService _tournamentService;
        private TournamentModel _tmpTournament;

        public TabItemTournament()
        {
            InitializeComponent();
            _tournamentService = new TournamentService();
            UpdateViewModel();
        }

        private void UpdateViewModel()
        {
            var tournamentViewModel = new TournamentViewModel();
            tournamentViewModel.Tournaments = _tournamentService.GetAllTournaments();
            DataContext = tournamentViewModel;
        }

        private void ButtonDataGridTournamentsDeleteClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var tournament = (TournamentModel)button.DataContext;
            _tournamentService.DeleteTournament(tournament.Id);
            UpdateViewModel();
        }

        private void ButtonTournamentsAddClick(object sender, RoutedEventArgs e)
        {
            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOn);
            ButtonUpdate.Visibility = Visibility.Collapsed;
            ButtonSave.Visibility = Visibility.Visible;
        }

        private void ButtonTournamentsBackClick(object sender, RoutedEventArgs e)
        {
            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOff);
        }

        private void ButtonTournamentsSaveClick(object sender, RoutedEventArgs e)
        {
            var tournametModel = new TournamentModel();
            tournametModel.Name = TextBoxName.Text;
            tournametModel.StartDate = (DateTime)DatePickerDayStart.SelectedDate;
            tournametModel.CloseDate = (DateTime)DatePickerDayClose.SelectedDate;
            tournametModel.Game = new GameModel { Id = 1, Name = "dsda" };
            _tournamentService.InsertTournament(tournametModel);
            UpdateViewModel();
        }

        private void ButtonDataGridTournamentsUpdateClick(object sender, RoutedEventArgs e)
        {
            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOn);
            ButtonUpdate.Visibility = Visibility.Visible;
            ButtonSave.Visibility = Visibility.Collapsed;
            var button = (Button)sender;
            var tournament = (TournamentModel)button.DataContext;
            _tmpTournament = new TournamentModel()
            {
                Id = tournament.Id,
                Name = tournament.Name,
                StartDate = tournament.StartDate,
                CloseDate = tournament.CloseDate,
                Game = tournament.Game
            };
            TextBoxName.Text = tournament.Name;
            DatePickerDayStart.SelectedDate = tournament.StartDate;
            DatePickerDayClose.SelectedDate = tournament.CloseDate;
        }

        private void ButtonTournamentsUpdateClick(object sender, RoutedEventArgs e)
        {
            var tournametModel = new TournamentModel();
            tournametModel.Id = _tmpTournament.Id;
            tournametModel.Name = TextBoxName.Text;
            tournametModel.StartDate = (DateTime)DatePickerDayStart.SelectedDate;
            tournametModel.CloseDate = (DateTime)DatePickerDayClose.SelectedDate;
            tournametModel.Game = _tmpTournament.Game;
            _tournamentService.UpdateTournament(tournametModel);
            UIHelpers.ChangeWidthGridColumns(columnsSaveUpdate, ColumnVisibilityOff);
            UpdateViewModel();
        }

        private void ButtonTournamentsOpenParticipants(object sender, RoutedEventArgs e)
        {
            DataGridTournaments.Visibility = Visibility.Collapsed;
            DataGridParticipants.Visibility = Visibility.Visible;
            ButtonCloseParticipants.Visibility = Visibility.Visible;
        }

        private void ButtonParticipantsCloseClick(object sender, RoutedEventArgs e)
        {
            DataGridTournaments.Visibility = Visibility.Visible;
            DataGridParticipants.Visibility = Visibility.Collapsed;
            ButtonCloseParticipants.Visibility = Visibility.Collapsed;
        }
    }
}
