using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TournamentOrganaizer.DataLayer.Entities;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.BusinessLayer.Configuration;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Tests
{
    public class TournamentServiceTests
    {
        private readonly Mock<ITournamentRepository> _tournamnetRepositoryMock;
        private readonly Mock<IGameRepository> _gameRepositoryMock;
        private readonly Mock<IResultTournamentPlayerRepository> _resultTournamentPlayerRepositoryMock;
        private readonly Mock<IResultTournamentTeamRepository> _resultTournamentTeamRepositoryMock;
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;
        private readonly Mock<ITeamRepository> _teamRepositoryMock;


        public TournamentServiceTests()
        {
            _tournamnetRepositoryMock = new Mock<ITournamentRepository>();
            _gameRepositoryMock = new Mock<IGameRepository>();
            _resultTournamentPlayerRepositoryMock = new Mock<IResultTournamentPlayerRepository>();
            _resultTournamentTeamRepositoryMock = new Mock<IResultTournamentTeamRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
            _teamRepositoryMock = new Mock<ITeamRepository>();
        }

        public void FillTestObjectsForGetAllTournaments()
        {
            _tournamnetRepositoryMock.Setup(m => m.TournamentSelectAll()).Returns(new List<Tournament>
            {
                new Tournament
                {
                    Id = 1,
                    Name = "Test1",
                    StartDate = DateTime.Now,
                    CloseDate = DateTime.Now,
                    Game = new Game
                    {
                        Id = 1,
                        Name = "TestGame"
                    }
                },
                new Tournament
                    {
                        Id = 2,
                        Name = "Test2",
                        StartDate = DateTime.Now,
                        CloseDate = DateTime.Now,
                        Game = new Game
                        {
                            Id = 1,
                            Name = "TestGame"
                        }
                }
            });
        }

        public void FillTestObjectsForGetAllPlayers()
        {
            _playerRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Player>
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

        public void FillTestObjectsForGetAllTeams()
        {
            _teamRepositoryMock.Setup(m => m.GetAll()).Returns(new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "Team1"
                },
                new Team
                {
                    Id = 2,
                    Name = "Team2"
                }
            });
        }

        public void FillTestObjectsForGetPlayersInTournament()
        {
            _resultTournamentPlayerRepositoryMock.Setup(m => m.GetPlayersInTournamentsByTournamentId(1)).Returns(new List<Player>
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
            _resultTournamentPlayerRepositoryMock.Setup(m => m.GetPlayersInTournamentsByTournamentId(2)).Returns(new List<Player>
            {
                new Player
                {
                    Id = 3,
                    FirstName = "Vasya3",
                    LastName = "Pupkin3",
                    Name = "Ybica20003",
                    Email = "test3",
                    Birthday = DateTime.Now
                },
                new Player
                {
                    Id = 4,
                    FirstName = "Vasya4",
                    LastName = "Pupkin4",
                    Name = "Ybica20004",
                    Email = "test4",
                    Birthday = DateTime.Now
                }
            });
        }

        public void FillTestObjectsForGetAllGames()
        {
            _gameRepositoryMock.Setup(m => m.GameSelectAll()).Returns(new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Name = "Test1",
                },
                new Game
                {
                    Id = 2,
                    Name = "Test2"
                }
            });
        }


        public void FillTestObjectsForGetTeamsInTournament()
        {
            _resultTournamentTeamRepositoryMock.Setup(m => m.GetTeamsInTournament(1)).Returns(new List<Team>
            {
                new Team
                {
                    Id = 1,
                    Name = "Test1",
                },
                new Team
                {
                    Id = 2,
                    Name = "Test2"
                }
            });
        }

        public TournamentModel GetTestTournamentsModelToFill(int key)
        {
            TournamentModel result;
            switch (key)
            {
                case 1:
                    result = new TournamentModel
                    {
                        Id = 1,
                        Name = "Test1",
                        StartDate = DateTime.Now,
                        CloseDate = DateTime.Now,
                        Game = new GameModel
                        {
                            Id = 1,
                            Name = "TestGame"
                        }
                    };
                    break;

                case 2:
                    result = new TournamentModel
                    {
                        Id = 2,
                        Name = "Test2",
                        StartDate = DateTime.Now,
                        CloseDate = DateTime.Now,
                        Game = new GameModel

                        {
                            Id = 1,
                            Name = "TestGame"
                        }
                    };
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        public PlayerModel GetTestPlayerForTestAddPalyerToTournamentTes(int key)
        {
            PlayerModel result;
            switch (key)
            {
                case 1:
                    result = new PlayerModel
                    {
                        Id = 1,
                        FirstName = "Vasya",
                        LastName = "Pupkin",
                        Name = "Ybica2000",
                        Email = "test",
                        Birthday = DateTime.Now
                    };
                    break;

                case 2:
                    result = new PlayerModel
                    {
                        Id = 2,
                        FirstName = "Vasya2",
                        LastName = "Pupkin2",
                        Name = "Ybica20002",
                        Email = "test2",
                        Birthday = DateTime.Now
                    };
                    break;
                default:
                    result = null;
                    break;
            }
            return result;

        }


        public TeamModel GetTestTeamsForTestAddPalyerToTournamentTes(int key)
        {
            TeamModel result;
            switch (key)
            {
                case 1:
                    result = new TeamModel
                    {
                        Id = 1,
                        Name = "Team1"
                    };
                    break;

                case 2:
                    result = new TeamModel
                    {
                        Id = 1,
                        Name = "Team2"
                    };
                    break;
                default:
                    result = null;
                    break;
            }
            return result;

        }



        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetAllTournaments_ShouldReturnTournamentsWithGamesInfo()
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);

            FillTestObjectsForGetAllTournaments();
            //act
            var actual = sut.GetAllTournaments();

            //assert
            _tournamnetRepositoryMock.Verify(m => m.TournamentSelectAll(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsNotNull(actual[0].Game);
            Assert.IsInstanceOf(typeof(TournamentModel), actual[0]);
            Assert.IsInstanceOf(typeof(GameModel), actual[0].Game);
            Assert.Pass();

        }


        [TestCase(1)]

        public void DeleteTournament_ShouldPass(int id)
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);

            //act
            sut.DeleteTournament(id);

            //assert
            _tournamnetRepositoryMock.Verify(m => m.TournamentDeleteById(id), Times.Once());
            Assert.Pass();
        }

        [TestCase(1)]

        public void UpdateTournament_ShouldPass(int key)
        {
            //arrange
            var tetsTournament = GetTestTournamentsModelToFill(key);
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);
            var tournament = CustomMapper.GetInstance().Map<Tournament>(tetsTournament);

            //act
            sut.UpdateTournament(tetsTournament);

            //assert
            _tournamnetRepositoryMock.Verify(m => m.TournamentUpdateById(It.IsAny<Tournament>()), Times.Once());
            Assert.Pass();

        }

        [TestCase(1)]

        public void InsertTournament_ShouldReturnId(int key)
        {
            //arrange
            var testTournament = GetTestTournamentsModelToFill(key);
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);

            //act
            var actual = sut.InsertTournament(testTournament);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            Assert.Pass();

        }

        [Test]

        public void GetAllGames_ShouldReturnAllAvailableGames()
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);
            FillTestObjectsForGetAllGames();
            //act
            var actual = sut.GetAllGames();

            //assert
            _gameRepositoryMock.Verify(m => m.GameSelectAll(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(GameModel), actual[0]);
            Assert.Pass();
        }

        [TestCase(1)]

        public void GetPlayersInTournament_ShouldRetuenPlayersInCurrentTournament(int key)
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);
            FillTestObjectsForGetPlayersInTournament();
            //act 
            var actual = sut.GetPlayersInTournament(key);

            //assert
            _resultTournamentPlayerRepositoryMock.Verify(m => m.GetPlayersInTournamentsByTournamentId(key), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(IParticipant), actual[0]);
            Assert.Pass();
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]

        public void DeletePlayerFromTournament_ShouldPass(int playerId, int tournamentId)
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);

            //act
            sut.DeletePlayerFromTournament(playerId, tournamentId);

            //assert
            _resultTournamentPlayerRepositoryMock.Verify(m => m.DeleteByTournament(playerId, tournamentId), Times.Once());
            Assert.Pass();
        }

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 2)]

        public void AddPalyerToTournament_ShouldReturnPlayerId(int key, int tournamentId)
        {
            //arrange
            var testPlayer = GetTestPlayerForTestAddPalyerToTournamentTes(key);
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);

            //act
            var actual = sut.AddPalyerToTournament(testPlayer, tournamentId);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            Assert.Pass();
        }

        [TestCase(1)]
        public void GetTeamsInTournament_ShouldReturnTeamsInTournament(int tournamentId)
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);
            FillTestObjectsForGetTeamsInTournament();

            //act
            var actual = sut.GetTeamsInTournament(tournamentId);

            //assert
            _resultTournamentTeamRepositoryMock.Verify(m => m.GetTeamsInTournament(1), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(TeamModel), actual[0]);
            Assert.Pass();
        }

        [TestCase(1,1)]
        public void DeleteTeamFromTournament_ShuldPass(int teamId, int tournamentId)
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);

            //act
            sut.DeleteTeamFromTournament(teamId,  tournamentId);

            //assert
            _resultTournamentTeamRepositoryMock.Verify(m => m.DeleteByTournament(tournamentId, teamId), Times.Once());
            Assert.Pass();
        }

        [TestCase (1, 1)]
        [TestCase (2, 1)]

        public void AddTeamToTournament(int key, int tournamentId)
        {
            //arrange
            var testTeam = GetTestTeamsForTestAddPalyerToTournamentTes(key);
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);

            //act
            var actual = sut.AddTeamToTournament(testTeam, tournamentId);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            Assert.Pass();
        }

        [Test]

        public void GetAllPlayers_SholudReturnAllPlayersList()
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);
            FillTestObjectsForGetAllPlayers();

            //act
            var actual = sut.GetAllPlayers();

            //assert
            _playerRepositoryMock.Verify(m => m.GetAll(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(PlayerModel), actual[0]);
            Assert.Pass();
        }

        [Test]

        public void GetAllTeams_SholudReturnAllTeamList()
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object, _playerRepositoryMock.Object, _teamRepositoryMock.Object, _resultTournamentTeamRepositoryMock.Object);
            FillTestObjectsForGetAllTeams();

            //act
            var actual = sut.GetAllTeams();

            //assert
            _teamRepositoryMock.Verify(m => m.GetAll(), Times.Once());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(TeamModel), actual[0]);
            Assert.Pass();
        }


    }
}