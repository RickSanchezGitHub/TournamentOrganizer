using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class ConverterParticipantName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is PlayerModel)
            {
                return ((PlayerModel)value).NickName;
            }
            else
            {
                return ((TeamModel)value).Name;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
