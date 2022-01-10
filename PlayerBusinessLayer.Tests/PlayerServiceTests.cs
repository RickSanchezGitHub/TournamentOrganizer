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
        private readonly Mock<ITeamPlayerRepository> _teamPlayerRepositoryMoq;

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


            var sut = new PlayerService(_playerRepositoryMoq.Object, _teamPlayerRepositoryMoq.Object);
            // act

            var actual = sut.GetAll();

            // assert

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count > 0);
            Assert.IsInstanceOf(typeof(PlayerModel), actual[0]);
        }

        public void FillTestObjectsForGetByIdPlayer()
        {
             _playerRepositoryMoq.Setup(m => m.GetById(1)).Returns(
              new Player
                    {
                        Id=1,
                        FirstName="TestVasya",
                        LastName="TestIvaniv",
                        Name="Vasya228",
                        Email="testc@yandex.ru",
                        Birthday= DateTime.Now
                    }
           );
        }

        [Test]
        public void GetByIdPlayer_ShouldReturnPlayers()
        {
            // arrange
            FillTestObjectsForGetByIdPlayer();


            var sut = new PlayerService(_playerRepositoryMoq.Object, _teamPlayerRepositoryMoq.Object);
            // act

            var actual = sut.GetById(1);

            // assert

            Assert.IsNotNull(actual);
           Assert.IsInstanceOf(typeof(PlayerModel), actual);
        }

        [Test]
        public void PlayerDelete()
        {
            //arrange
           

            var sut = new PlayerService(_playerRepositoryMoq.Object, _teamPlayerRepositoryMoq.Object);

            //act
            sut.DeleteById(1);

            //assert
            _playerRepositoryMoq.Verify(m => m.Delete(1), Times.Once());
            Assert.Pass();
        }

        public PlayerModel GetTestTournamentsModelToFill(int key)
        {
            PlayerModel result;
            switch (key)
            {
                case 1:
                    result = new PlayerModel
                    {
                        Id = 1,
                        FirstName = "TestVasya",
                        LastName = "TestIvaniv",
                        Name = "Vasya228",
                        Email = "testc@yandex.ru",
                        Birthday = DateTime.Now
                    };
                    break;

                case 2:
                    result = new PlayerModel
                    {
                        Id = 2,
                        FirstName = "TestVasya",
                        LastName = "TestIvaniv",
                        Name = "Vasya228",
                        Email = "testc@yandex.ru",
                        Birthday = DateTime.Now
                    };
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }
       
        [TestCase(1)]
        [TestCase(2)]

        public void InsertPlayerById(int key)
        {
            //arrange
            var testPlayer = GetTestTournamentsModelToFill(key);
            var sut = new PlayerService(_playerRepositoryMoq.Object, _teamPlayerRepositoryMoq.Object);

            //act
            var actual = sut.InsertPlayer(testPlayer);

            //assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf(typeof(int), actual);
            Assert.Pass();

        }

        [TestCase(1)]
        public void PlayerUpDateShouldPass(int key)
        {
            //arrange

           var player = GetTestTournamentsModelToFill(key);
            var sut = new PlayerService(_playerRepositoryMoq.Object, _teamPlayerRepositoryMoq.Object);

            //act
            sut.PlayerUpdate(1, player );

            //assert
            _playerRepositoryMoq.Verify(m => m.Update(1, It.IsAny<Player>() ), Times.Once());
            Assert.Pass();
        }

       

    }
}