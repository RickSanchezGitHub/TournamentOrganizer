using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TournamentOrganizer.UI.VeiwModels
{
    class ConverterResultsToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 2)
            {
                return "Победил";
            }
            else if((int)value == 1)
            {
                return "Ничья";
            }
            else
            {
                return "Проиграл";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
