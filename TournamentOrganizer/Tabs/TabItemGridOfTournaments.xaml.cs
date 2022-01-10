using System;
using System.Collections.Generic;
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
        //CommandBinding OpenCmdBinding = new CommandBinding(
        //    ApplicationCommands.Open,
        //    Command_Execute);


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var data = button.DataContext;
            _viewModel.SelectedButton = button;
            _viewModel.SelctedMatchInTreeView = (MatchModel)data;
            _viewModel.VisibilityStackPanelMatchResolve = Visibility.Visible;
            _viewModel.VisibilityDataGridShowTournamentParticipants = Visibility.Collapsed;
            _viewModel.VisibilityStackPanelRedistributeParticipants = Visibility.Collapsed;
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
                    NumberRound = _viewModel.NewRound.RoundNumber
                };
                match.TeamsResults.Add(result);
            }
                
            else 
            {
                var result = new ResultTournamentPlayerModel
                {
                    Player = (PlayerModel)participant,
                    NumberMatch = match.MatchNumber,
                    NumberRound = _viewModel.NewRound.RoundNumber
                };
                match.PlayersResults.Add(result);
            }
            _viewModel.ParticipantsForRedistribution.Remove((IParticipant)participant);
            if(match.Participants.Count == 2)
                MessageBox.Show("Пара сформирована!");
        }
    }
}
