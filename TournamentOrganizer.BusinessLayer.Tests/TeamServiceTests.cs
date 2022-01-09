using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Tests
{
    public class TeamServiceTests
    {
        private readonly Mock<ITeamRepository> _teamRepositoryMock;
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;
        private readonly Mock<ITeamPlayerRepository> _teamPlayerRepositoryMock;
        public TeamServiceTests()
        {
            _teamRepositoryMock = new Mock<ITeamRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
            _teamPlayerRepositoryMock = new Mock<ITeamPlayerRepository>();
        }

        public void FillTestObjectsForGetAllTeam()
        {
            _teamRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "Test1"
                },
                new Team
                {
                    Id = 2,
                    Name = "Teast2"
                },
                new Team
                {
                    Id = 3,
                    Name = "Teast3"
                }
            });
        }
        public void FillTestObjectsForGetPlayersInTeams()
        {

        }
    }
}
