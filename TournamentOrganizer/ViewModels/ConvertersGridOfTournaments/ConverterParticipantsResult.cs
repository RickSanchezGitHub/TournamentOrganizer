using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class ConverterParticipantsResult : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<ResultTournamentPlayerModel>)
            {
                return ((ResultTournamentPlayerModel)value).Player.Name;
            }
            else if (value is ObservableCollection<ResultTournamentTeamModel>)
            {
                return ((ResultTournamentTeamModel)value).Team.Name;
            }
            else
            {
                return "Name";
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
