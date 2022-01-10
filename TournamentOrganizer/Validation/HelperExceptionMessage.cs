using System.Windows;

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
