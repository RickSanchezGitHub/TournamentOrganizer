using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;

namespace TournamentOrganizer.BusinessLayer.Service
{
    public interface ITeamPlayerService
    {
        void Delete(TeamPlayerModel teamPlayerModel);
        int Insert(TeamPlayerModel teamPlayer);

    }
}
