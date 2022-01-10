using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service.TeamService;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Tests
{
    public class TeamServiceTests
    {
        private readonly Mock<ITeamRepository> _teamRepositoryMock;
        
        public TeamServiceTests()
        {
            _teamRepositoryMock = new Mock<ITeamRepository>();
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

        public void FillTestObjectsForGetGyIdTeam()
        {
            _teamRepositoryMock.Setup(m => m.GetById(1)).Returns(new Team
            {
                Id = 1,
                Name = "TestTeam",
                Players= new List<Player>
                {
                    new Player
                    {
                        Id=1,
                        FirstName="TestVasya",
                        LastName="TestIvaniv",
                        Name="Vasya228",
                        Email="testc@yandex.ru",
                        Birthday= DateTime.Now
                    },
                    new Player
                    {
                        Id=2,
                        FirstName="TestVitya",
                        LastName="TestVasin",
                        Name="Vitya228",
                        Email="testVitya@yandex.ru",
                        Birthday= DateTime.Now
                    }
                }
            });
        }

        public TeamModel GetTestTeamModelToFill()
        {
            TeamModel result = new TeamModel
            {
                Id = 1,
                Name = "Test1"
            };                    
            return result;
        }

        public void FillTestObjectsForGetAvailablePlayersToAdd()
        {
            _teamRepositoryMock.Setup(m => m.GetAvailablePlayersToAdd(1)).Returns(new List<Player>
            {
                new Player
                {
                    Id = 1,
                    FirstName = "Vasya",
                    LastName = "Pupkin",
                    Name = "Ybica2000",
                    Email = "test",
                    Birthday = DateTime.Now
                },
                new Player
                {
                    Id = 2,
                    FirstName = "Vasya2",
                    LastName = "Pupkin2",
                    Name = "Ybica20002",
                    Email = "test2",
                    Birthday = DateTime.Now
                }
            });
        }

        [Test]
        public void GetAllTeams_ShouldReturnAllTeams()
        {
            //arrange
            var sut = new TeamService(_teamRepositoryMock.Object);
            FillTestObjectsForGetAllTeam();

            //act
            var actual = sut.GetAll();

            //assert
            _teamRepositoryMock.Verify(m => m.GetAll(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Players);
            Assert.Pass();

        }

        [Test]
        public void GetById_ShouldReturnTeamWithPlayersInto()
        {
            //arrange
            var sut = new TeamService(_teamRepositoryMock.Object);
            FillTestObjectsForGetGyIdTeam();

            //act
            var actual = sut.GetById(1);

            //assert
            _teamRepositoryMock.Verify(m => m.GetById(1), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Players[0]);
            Assert.Pass();
        }

        [Test]
        public void Insert_ShouldPass()
        {
            //arrange
            var testTeam = GetTestTeamModelToFill();
            var sut = new TeamService(_teamRepositoryMock.Object);

            //act
            var actual = sut.Insert(testTeam);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            Assert.Pass();
        }

        [TestCase(1)]
        public void Delete_ShouldPass(int id)
        {
            //arrange
            var sut = new TeamService(_teamRepositoryMock.Object);

            //act
            sut.Delete(id);

            //assert
            _teamRepositoryMock.Verify(m => m.Delete(id), Times.Once());
            Assert.Pass();
        }
        

        [TestCase(1)]
        public void Update_ShouldPass(int key)
        {
            //arrange
            var tetsTeam = GetTestTeamModelToFill();
            var sut = new TeamService(_teamRepositoryMock.Object);
            var tournament = CustomMapper.GetInstance().Map<Team>(tetsTeam);

            //act
            sut.Update(key, tetsTeam);

            //assert
            _teamRepositoryMock.Verify(m => m.Update(key, It.IsAny<Team>()), Times.Once());
            Assert.Pass();
        }

        [Test]
        public void GetAvailablePlayersToAdd_ShouldReturnAllPlayersFromTheTeam()
        {
            //arrange
            var sut = new TeamService(_teamRepositoryMock.Object);
            FillTestObjectsForGetAvailablePlayersToAdd();

            //act
            var actual = sut.GetAvailablePlayersToAdd(1);

            //assert
            _teamRepositoryMock.Verify(m => m.GetAvailablePlayersToAdd(1), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.Pass();
        }
    }
}
