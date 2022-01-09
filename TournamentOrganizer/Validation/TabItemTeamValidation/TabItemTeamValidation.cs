using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Validation.TabItemTeamValidation
{
    public class TabItemTeamValidation
    {
        private TabItemTeamViewModel _viewModel;
        public TabItemTeamValidation(TabItemTeamViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public bool CheckIsEmptyOrWtiteSpaceInputData()
        {
            bool canExecute = true;
            if(Validation.TextBoxValidationIsEmptyOrWriteSpace(_viewModel.TextBoxName))
            {
                canExecute = false;
            }
            return canExecute;
        }
        
        public bool CheckValidInputData()
        {
            bool canExecute = true;
            if(Validation.TextBoxValidation(_viewModel.TextBoxName))
            {
                canExecute = false;
            }
            return canExecute;
        }

        public bool CheckIsEmptySelectedTeam()
        {
            bool canExecute = true;
            if(_viewModel.SelectedTeam == null)
            {
                canExecute = false;
            }
            return canExecute;
        }
    }
}
