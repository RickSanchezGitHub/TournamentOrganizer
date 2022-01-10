using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class DeletePlayerCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        private readonly IPlayerService _playerService;

        public DeletePlayerCommand(TabItemPlayerViewModel viewModel, IPlayerService playerService) : base()
        {
            _viewModel = viewModel;
            _playerService = playerService;
        }

        public override void Execute(object parameter)
        {
            _viewModel.Teams.Clear();
            foreach (var item in _playerService.GetTeamsByPlayerId(_viewModel.SelectedPlayer.Id))
                _viewModel.Teams.Add(item);

            if (_viewModel.Teams.Count > 0)
            {
                MessageBox.Show("Для возможности удаления игрок не должен состоять в командах");
                return;
            }

            _playerService.DeleteById(_viewModel.SelectedPlayer.Id);
            _viewModel.Players.Remove(_viewModel.SelectedPlayer);
            
        }
    }
}