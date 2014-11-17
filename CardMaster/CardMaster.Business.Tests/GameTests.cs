using System;
using System.Collections.Generic;
using CardMaster.Business.Enums;
using CardMaster.Business.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace CardMaster.Business.Tests
{
    [TestFixture]
    public class GameTests
    {
        public List<Player> ValidPlayers { get; set; }

        [SetUp]
        public void Setup()
        {
            ValidPlayers = new List<Player>
            {
                new Player("Saurabh"),
                new Player("Teju"),
                new Player("Shinchan"),
                new Player("Himani")
            };
        }

        [Test]
        public void Game_should_show_status_as_inprogress_when_started()
        {
            //Arrange
            Game game = new Game(ValidPlayers);

            //Act
            game.Start();

            //Assert
            game.Status.Should().Be(GameStatus.InProgress);
        }

        [Test]
        public void Game_should_throw_exception_when_it_is_inprogress_and_start_is_called()
        {
            //Arrange
            Game game = new Game(ValidPlayers);

            //Act
            game.Start();
            Action action = game.Start;

            //Assert
            action.ShouldThrow<GameInProgressException>().WithMessage("Game is already in-progress");
        }

        [Test]
        public void Game_should_throw_exception_when_players_are_less_than_4()
        {
            //Arrange
            Game game = new Game(new List<Player>());

            //Act
            Action action = game.Start;

            //Assert
            action.ShouldThrow<NotEnoughPlayersException>().WithMessage("Minimum 4 players required to play the game");
        }

        [Test]
        public void Game_number_of_round_should_be_configurable()
        {
            //Arrange
            Game game = new Game(ValidPlayers);

            //Act
            game.SetRounds(5);

            //Assert
            game.GetRounds().Should().Be(5);
        }

        [Test]
        public void Game_number_of_round_should_not_allow_changes_when_game_is_progress()
        {
            //Arrange
            Game game = new Game(ValidPlayers);

            //Act
            game.SetRounds(5);
            game.Start();
            Action action = () => game.SetRounds(2);
            //Assert
            game.GetRounds().Should().Be(5);
            action.ShouldThrow<GameInProgressException>().WithMessage("Game is already in-progress");
        }
    }
}