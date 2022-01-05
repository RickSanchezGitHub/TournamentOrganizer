using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Commands.TabItemPlayerCommands
{
    public  class ValidationTabItemPlayer 
    {

        private TabItemPlayerViewModel _viewModel;

        public ValidationTabItemPlayer(TabItemPlayerViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CheckIsEmptyOrWhiteSpaceInputData()
        {
            bool canExecute = true;

            if (Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxFirstNameText) &&
             Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxLastNameText) &&
             Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxEmailText) &&
             Validation.TextBoxValidationIsEmptyOrWhiteSpace(_viewModel.TextBoxNickNameText))
            {
                canExecute = false;
            }
            return canExecute;
        }

        public bool CheckIsValidInputData()
        {
            bool canExecute = true;

            if (Validation.TextBoxValidation(_viewModel.TextBoxFirstNameText) &&
                Validation.TextBoxValidation(_viewModel.TextBoxLastNameText))
            {
                canExecute = false;
            }
            return canExecute;
        }

    }
}
