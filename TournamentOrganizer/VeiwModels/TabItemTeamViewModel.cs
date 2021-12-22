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
    public class TabItemTeamViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TeamModel> Teams { get; set; }
        public TabItemTeamViewModel()
        {
            Teams = new ObservableCollection<TeamModel>
            {
                new TeamModel{Id = 1, Name = "Test1", Players = new ObservableCollection<PlayerModel>
                { new PlayerModel {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Ильин",
                    NickName = "plater1", 
                    Email = "aaa@aa.ru", 
                    Birthday = new DateTime(2000-12-11) }
                } },
                new TeamModel{Id = 2, Name = "Test2", Players = new ObservableCollection<PlayerModel>
                { new PlayerModel{
                    Id = 1,
                    FirstName = "Вася",
                    LastName = "Ильин",
                    NickName = "player2",
                    Email = "aaa@aa.ru",
                    Birthday = new DateTime(2000-12-11)
                }, new PlayerModel {
                    Id = 2,
                    FirstName = "костя",
                    LastName = "Костин",
                    NickName = "player0",
                    Email = "aaa@aa.ru",
                    Birthday = new DateTime(2000-12-11)
                } } }
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
