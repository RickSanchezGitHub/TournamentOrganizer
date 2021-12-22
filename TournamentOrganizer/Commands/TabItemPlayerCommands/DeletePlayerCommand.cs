using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands
{
    public class DeletePlayerCommand : CommandBase
    {
        private TabItemPlayerViewModel _viewModel;

        public DeletePlayerCommand(TabItemPlayerViewModel viewModel) : base()
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.PlayerService.DeleteById(_viewModel.SelectedDeletePlayer.Id);
            _viewModel.Players.Remove(_viewModel.SelectedDeletePlayer);
            
        }
    }
}