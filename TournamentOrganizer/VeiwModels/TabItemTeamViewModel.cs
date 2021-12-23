using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.UI.Commands.TeamCommands;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TabItemTeamViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TeamModel> Teams { get; set; }
        private readonly ITeamService _teamService;
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand GetAllTeamCommand { get; set; }
        public ICommand GetByIdTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }
        public TabItemTeamViewModel()
        {
            Teams = new ObservableCollection<TeamModel>
            {
                new TeamModel
                {
                    Id = 1,
                    Name = "FirstTeam",
                    Players = new ObservableCollection<PlayerModel> {
                        new PlayerModel
                        {
                            Id = 1,
                            FirstName = "Player1",
                            LastName = "LastName1",
                            NickName ="Nick1",
                            Email = "aaaa@AAA",
                            Birthday =  new DateTime(1999-02-10)
                        },
                        new PlayerModel
                        {
                            Id = 1,
                            FirstName =" Player2",
                            LastName = "LastName2",
                            NickName = "Nick1",
                            Email = "bbb@BBB",
                            Birthday =  new DateTime(1888-05-11)
                        }
                    }
                }
            };
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
