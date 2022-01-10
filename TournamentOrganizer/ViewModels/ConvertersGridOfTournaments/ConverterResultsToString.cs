using System;
using System.Globalization;
using System.Windows.Data;

namespace TournamentOrganizer.UI.VeiwModels
{
    class ConverterResultsToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int?)value == 2)
            {
                return "Победил";
            }
            else if ((int?)value == 1)
            {
                return "Ничья";
            }
            else if ((int?)value == 0)
            {
                return "Проиграл";
            }
            else
            {
                return "Не играл";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
