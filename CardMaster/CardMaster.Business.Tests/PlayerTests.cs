using System.Collections.Generic;
using CardMaster.Business.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace CardMaster.Business.Tests
{
    [TestFixture]
    public class PlayerTests
    {

        [Test]
        public void Player_should_have_an_id_and_name_to_identify_them()
        {
            //Arrange
            const string name = "Saurabh";
            Player player = new Player(name);

            //Act

            //Assert
            player.Name.Should().Be(name);
        }

        [Test]
        public void Player_DrawCard_should_retun_same_card_that_was_distributed_to_the_player()
        {
            //Arrange
            const string name = "Saurabh";
            Player player = new Player(name);
            Card card = new Card(CardSuite.Diamond, CardFace.Ace);

            //Act
            player.AcceptCard(card);

            //Assert
            player.DrawCard().Suite.Should().Be(CardSuite.Diamond);
            player.DrawCard().Face.Should().Be(CardFace.Ace);
        }

        [Test]
        public void Player_ClearCard_when_called_should_reset_player_card_to_NULL()
        {
            //Arrange
            const string name = "Saurabh";
            Player player = new Player(name);
            Card card = new Card(CardSuite.Diamond, CardFace.Ace);

            //Act
            player.AcceptCard(card);

            ICard firstCard = player.DrawCard();

            player.ResetCard();

            ICard secondCard = player.DrawCard();

            //Assert
            firstCard.Suite.Should().Be(CardSuite.Diamond);
            firstCard.Face.Should().Be(CardFace.Ace);
            secondCard.Should().Be(null);
        }

        [Test]
        public void Player_DistributeCards_should_distribute_cards_to_player_in_given_order()
        {
            //Arrange
            CardDeck deck = new CardDeck();

            List<ICardPlayer> players = new List<ICardPlayer>
            {
                new Player("Teju"),
                new Player("Himani")
            };

            Player distributor = new Player("Saurabh");

            //Act
            deck.Shuffle();
            ICard firstCard = deck.Cards[0];
            ICard secondCard = deck.Cards[1];
            ICard thirdCard = deck.Cards[2];

            distributor.DistributeCards(deck, players);

            //Assert
            distributor.DrawCard().Suite.Should().Be(firstCard.Suite);
            distributor.DrawCard().Face.Should().Be(firstCard.Face);

            players[0].DrawCard().Suite.Should().Be(secondCard.Suite);
            players[0].DrawCard().Face.Should().Be(secondCard.Face);

            players[1].DrawCard().Suite.Should().Be(thirdCard.Suite);
            players[1].DrawCard().Face.Should().Be(thirdCard.Face);
        }
    }
}