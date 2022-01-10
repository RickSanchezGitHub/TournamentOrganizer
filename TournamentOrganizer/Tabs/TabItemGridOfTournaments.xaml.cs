using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Tabs
{
    /// <summary>
    /// Логика взаимодействия для TabItemGridOfTournaments.xaml
    /// </summary>
    public partial class TabItemGridOfTournaments : TabItem
    {
        private TabItemGridOfTournamentsViewModel _viewModel;
        public TabItemGridOfTournaments()
        {
            _viewModel = new();
            InitializeComponent();
            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var data = button.DataContext;
            _viewModel.SelectedButton = button;
            _viewModel.SelctedMatchInTreeView = (MatchModel)data;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Visible;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelRedistributeParticipants = Visibility.Collapsed;
            _viewModel.ShowParticipantsTournamentResult = "Показать участников турнира";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var participant = button.DataContext;
            var match = _viewModel.NewRound.Matchs.First(item => item.Participants.Count != 2);
            match.Participants.Add((IParticipant)participant);
            if (_viewModel.SelectedTournament.OnlyForTeams)
            {
                var result = new ResultTournamentTeamModel
                {
                    Team = (TeamModel)participant,
                    NumberMatch = match.MatchNumber,
                    NumberRound = _viewModel.NewRound.RoundNumber,
                    Tournament = _viewModel.SelectedTournament
                };
                match.ParticipantsResults.Add(result);
            }

            else
            {
                var result = new ResultTournamentPlayerModel
                {
                    Player = (PlayerModel)participant,
                    NumberMatch = match.MatchNumber,
                    NumberRound = _viewModel.NewRound.RoundNumber,
                    Tournament = _viewModel.SelectedTournament
                };
                match.ParticipantsResults.Add(result);
            }
            _viewModel.ParticipantsForRedistribution.Remove((IParticipant)participant);
            if (match.Participants.Count == 2)
                MessageBox.Show("Пара сформирована!");

            if (_viewModel.ParticipantsForRedistribution.Count == 0) { }
            _viewModel.IsEnabledButtonSaveRedistributeParticipants = true;
        }
    }
}
