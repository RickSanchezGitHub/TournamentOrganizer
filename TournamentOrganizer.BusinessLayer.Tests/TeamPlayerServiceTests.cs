using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamPlayerService;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Tests
{
    public class TeamPlayerServiceTests
    {
        private readonly Mock<ITeamPlayerRepository> _teamPlayerRepositoryMock;

        public TeamPlayerServiceTests()
        {
            _teamPlayerRepositoryMock = new Mock<ITeamPlayerRepository>();
        }

        public TeamPlayer GetTestTeamPlayerToFill()
        {
            TeamPlayer result = new TeamPlayer
            {
                Id = 1,
                TeamId = 1,
                PlayerId = 1
            };
            return result;
        }

        public TeamPlayerModel GetTestTeamPlayerModelToFill()
        {
            TeamPlayerModel result = new TeamPlayerModel
            {
                Id = 1,
                TeamId = 1,
                PlayerId = 1
            };
            return result;
        }

        [Test]
        public void TeamPlayerDelete()
        {
            //arrange
            var teamPlayerTestModel = GetTestTeamPlayerModelToFill();
            var teamPlayerTest = GetTestTeamPlayerToFill();

            var sut = new TeamPlayerService(_teamPlayerRepositoryMock.Object);

            //act
            sut.Delete(teamPlayerTestModel);

            //assert
            _teamPlayerRepositoryMock.Verify(m => m.Delete(It.IsAny<TeamPlayer>()), Times.Once());
            Assert.Pass();
        }

        [Test]
        public void TeamPlayerInsert()
        {
            //arrange
            var teamPlayerTestModel = GetTestTeamPlayerModelToFill();
            var teamPlayerTest = GetTestTeamPlayerToFill();

            var sut = new TeamPlayerService(_teamPlayerRepositoryMock.Object);

            //act
            sut.Insert(teamPlayerTestModel);

            //assert
            _teamPlayerRepositoryMock.Verify(m => m.Insert(It.IsAny<TeamPlayer>()), Times.Once());
            Assert.Pass();
        }
    }
}
