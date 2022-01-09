using NUnit.Framework;
using TournamentOrganizer.BusinessLayer.Models;
using TournamentOrganizer.BusinessLayer.Service;
using Moq;
using TournamentOrganizer.DataLayer.Repositories;
using System.Collections.Generic;
using TournamentOrganizer.DataLayer.Entities;
using System;

namespace PlayerBusinessLayer.Tests
{
    public class PlayerServiceTests
    {
        private readonly Mock<IPlayerRepository> _playerRepositoryMoq;

        public PlayerServiceTests()
        {
            _playerRepositoryMoq = new Mock<IPlayerRepository>();
        }

        [SetUp]
        public void Setup()
        {
        }

        private void  GetTestDataForGetAllPlayers()
        {
            _playerRepositoryMoq.Setup(m => m.GetAll()).Returns(new List<Player>
            {
            new Player
            {
                Id=1, FirstName="namefirst",
                LastName="Lastnamefirst",
                Name = "nick first",
                Email= "email first",
                Birthday= DateTime.Now.AddYears(-20)
            }
            });
        }


        [Test]
        public void GetAllPayers_ShouldReturnPlayers()
        {
            // arrange
            GetTestDataForGetAllPlayers();


            var sut = new PlayerService(_playerRepositoryMoq.Object);
            // act

            var actual = sut.GetAll();

            // assert

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(PlayerModel), actual[0]);
        }
    }
}