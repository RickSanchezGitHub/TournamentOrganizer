using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganizer.BusinessLayer.Models
{
    public class ResultTournamentPlayerModel: INotifyPropertyChanged
    {
        public int Id { get; set; }
        public PlayerModel Player { get; set; }
        public int Result { get; set; }
        public int NumberRound { get; set; }
        public int NumberMatch { get; set; }
        public TournamentModel Tournament { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
