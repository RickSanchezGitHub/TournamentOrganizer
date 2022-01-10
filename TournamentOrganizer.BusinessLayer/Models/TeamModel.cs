using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class TeamModel : INotifyPropertyChanged
    {

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PlayerModel> _players { get; set; }
        public ObservableCollection<PlayerModel> Players 
        {
            get
            {
                return _players ?? new ObservableCollection<PlayerModel>();
            }
            set
            {
                _players = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public override bool Equals(object obj)
        {
            return obj is TeamModel model &&
                   Id == model.Id &&
                   Name == model.Name &&
                   EqualityComparer<ObservableCollection<PlayerModel>>.Default.Equals(Players, model.Players);
        }
    }
}
