using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.UI.Command;
using TournamentOrganizer.UI.Validation.TabItemTeamValidation;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Validation
{
    public static class HelperExceptionMessage
    {
        public static void HelperMessageBox(string messageException)
        {
            switch (messageException)
            {
                case "CheckIsEmptyOrWtiteSpaceInputData":
                    MessageBox.Show("Заполните поле",
                                "Ошибка ",
                                MessageBoxButton.OK);
                    return;
                case "CheckValidInputData":
                    MessageBox.Show("Название не должно содержать никаких символов, пробелов и не должно превышать 25 символов",
                                "Ошибка ",
                                MessageBoxButton.OK);
                    return;
                case "CheckIsEmptySelectedTeam":
                    MessageBox.Show("Выберите команду",
                                "Ошибка ",
                                MessageBoxButton.OK);
                    return;
                default:
                    MessageBox.Show("Неизвестная ошибка. Обратитесь в тех. поддержку",
                                "Ошибка ",
                                MessageBoxButton.OK);
                    return;
            }
        }
    }
}
