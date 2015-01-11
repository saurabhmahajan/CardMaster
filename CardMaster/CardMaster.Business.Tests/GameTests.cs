using System;
using System.Collections.Generic;
using CardMaster.Business.CardRules;
using CardMaster.Business.Enums;
using CardMaster.Business.Exceptions;
using CardMaster.Business.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace CardMaster.Business.Tests
{
    [TestFixture]
    public class GameTests
    {
        private const int NoOfRounds = 5;
        private List<ICardPlayer> _validPlayers;
        private GameSettings _gameSettings;
        private List<CardSuite> _cardSuitePriority;

        [SetUp]
        public void Setup()
        {
            _validPlayers = new List<ICardPlayer>
            {
                new Player("Saurabh"),
                new Player("Teju"),
                new Player("Savi"),
                new Player("Himani")
            };

            _cardSuitePriority = new List<CardSuite>
            {
                CardSuite.Diamond,
                CardSuite.Heart,
                CardSuite.Club,
                CardSuite.Spade
            };

            _gameSettings = new GameSettings(new CardDeck(), NoOfRounds, new SuitePriorityCardRule(_cardSuitePriority));
        }

        [Test]
        public void Game_should_show_status_as_inprogress_when_started()
        {
            //Arrange
            Game game = new Game(_validPlayers, _gameSettings);

            //Act
            game.Start();

            //Assert
            game.Status.Should().Be(GameStatus.InProgress);
        }

        [Test]
        public void Game_should_throw_exception_when_it_is_inprogress_and_start_is_called()
        {
            //Arrange
            Game game = new Game(_validPlayers, _gameSettings);

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
            Game game = new Game(new List<ICardPlayer>(), _gameSettings);

            //Act
            Action action = game.Start;

            //Assert
            action.ShouldThrow<NotEnoughPlayersException>().WithMessage("Minimum 4 players required to play the game");
        }

        [Test]
        public void Game_number_of_round_should_be_a_positive_number()
        {
            //Arrange
            Game game = new Game(_validPlayers, new GameSettings(new CardDeck(), 0, new SuitePriorityCardRule(_cardSuitePriority)));

            //Act
            Action action = game.Start;

            //Assert
            action.ShouldThrow<InvalidRoundCountException>().WithMessage("Round count should be greater than 0");
        }

        //[Test]
        //public void Game_should_return_a_winner_when_finished()
        //{
        //    //Arrange
        //    Game game = new Game(_validPlayers, _gameSettings);

        //    //Act
        //    game.

        //    //Assert

        //}
    }
}