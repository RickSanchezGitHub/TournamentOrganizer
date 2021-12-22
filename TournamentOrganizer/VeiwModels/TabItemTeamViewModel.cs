using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemTeamViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TeamModel> Teams { get; set; }
        private TeamService _teamService;
        public TabItemTeamViewModel()
        {
            _teamService = new TeamService();
            Teams = new ObservableCollection<TeamModel>(_teamService.GetAll());
        }

        private TeamModel _selectedTeam;

        public TeamModel SelectedTeam { get => _selectedTeam; set => Set(ref _selectedTeam, value); }      
        


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public bool Set<T>(ref T field, T value, [CallerMemberName] string prop = "")
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(prop);
            return true;
        }

    }
}
