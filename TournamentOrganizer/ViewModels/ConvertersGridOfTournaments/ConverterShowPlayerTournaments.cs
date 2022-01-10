using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class ConverterShowPlayerTournaments : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool)value || value == null)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

