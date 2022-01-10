using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TournamentOrganaizer.DataLayer.Entities;
using TournamentOrganaizer.DataLayer.Repositories;
using TournamentOrganizer.DataLayer.Entities;
using TournamentOrganizer.DataLayer.Repositories;

namespace TournamentOrganizer.BusinessLayer.Tests
{
    public class ResultTournamentPlayerTests
    {
        private readonly Mock<IResultTournamentPlayerRepository> _resultTournamentPlayerRepositoryMock;
        private readonly Mock<ITournamentRepository> _tournamnetRepositoryMock;
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;

        public ResultTournamentPlayerTests()
        {
            _resultTournamentPlayerRepositoryMock = new Mock<IResultTournamentPlayerRepository>();
            _tournamnetRepositoryMock = new Mock<ITournamentRepository>();
            _playerRepositoryMock = new Mock<IPlayerRepository>();
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
            _playerRepositoryMock.Setup(m => m.GetPlayersInTournament(1)).Returns(new List<Player>
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
            _playerRepositoryMock.Setup(m => m.GetPlayersInTournament(2)).Returns(new List<Player>
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





        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}