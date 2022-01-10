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

        public TournamentServiceTests()
        {
            _tournamnetRepositoryMock = new Mock<ITournamentRepository>();
            _gameRepositoryMock = new Mock<IGameRepository>();
            _resultTournamentPlayerRepositoryMock = new Mock<IResultTournamentPlayerRepository>();

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



        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetAllTournaments_ShouldReturnTournamentsWithGamesInfo()
        {
            //arrange
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);
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
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);

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
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);
            var tournament = CustomMapper.GetInstance().Map<Tournament>(tetsTournament);

            //act
            sut.UpdateTournament(tetsTournament);

            //assert
            _tournamnetRepositoryMock.Verify(m => m.TournamentUpdateById(tournament), Times.Once());
            Assert.Pass();

        }

        [TestCase(1)]

        public void InsertTournament_ShouldReturnId(int key)
        {
            //arrange
            var testTournament = GetTestTournamentsModelToFill(key);
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);

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
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);
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
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);
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
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);

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
            var sut = new TournamentService(_tournamnetRepositoryMock.Object, _gameRepositoryMock.Object, _resultTournamentPlayerRepositoryMock.Object);

            //act
            var actual = sut.AddPalyerToTournament(testPlayer, tournamentId);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            Assert.Pass();
        }

    }
}