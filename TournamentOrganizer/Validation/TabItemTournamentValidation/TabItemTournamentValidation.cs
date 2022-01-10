using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.UI.VeiwModels;

namespace TournamentOrganizer.UI.Validation.TabItemTournamentValidation
{
    public static class TabItemTournamentValidation
    {
        public static bool AddParticipantToTournamentValidation(IParticipant selectedTournamentParticipant, ObservableCollection<IParticipant> allParticipants)
        {
            bool isValid = true;
            if (allParticipants.Contains(selectedTournamentParticipant))
            {
                isValid = false;
            }
            return isValid;
        }

        public static bool DeleteTournamentValidation(ObservableCollection<IParticipant> tournamentParticipants)
        {
            bool isValid = true;
            if (tournamentParticipants.Count > 0)
            {
                isValid = false;
            }
            return isValid;
        }

    }
}
