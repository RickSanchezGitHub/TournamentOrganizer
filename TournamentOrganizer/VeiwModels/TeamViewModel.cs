using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.UI.VeiwModels
{
    public class TeamViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TeamModel> Teams { get; set; }

        public TeamViewModel()
        {
            Teams = new ObservableCollection<TeamModel>
            {
                new TeamModel{Id = 1, Name = "Test1", Players = new ObservableCollection<PlayerModel>
                { new PlayerModel {
                    Id = 1,
                    FirstName = "FirstName",
                    LastName = "LastName",
                    NickName = "NickName", 
                    Email = "aaaaa", 
                    Birthday = new DateTime(2000-12-11) }
                } },
                new TeamModel{Id = 2, Name = "Test2", Players = new ObservableCollection<PlayerModel>
                { new PlayerModel{
                    Id = 2, 
                    FirstName = "TestPlayer2"
                }, new PlayerModel { 
                    Id = 1, 
                    FirstName = "Suuuuukaaaaaa" 
                } } }
            };
        }

        private TeamModel _selectedTeam;

        public TeamModel SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                OnPropertyChanged("SelectedTeam");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
