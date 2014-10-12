using System.Collections.Generic;
using CardMaster.Business.Enums;
using CardMaster.Business.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace CardMaster.Business.Tests
{
    [TestFixture]
    public class CardRuleTests
    {
        [Test]
        public void CardRule_GetWinningCard_should_return_diamond_card_when_all_cards_of_different_suit_with_same_value_provided()
        {
            //Arrange
            List<ICard> cards = new List<ICard>
            {
                new Card(CardSuite.Club, CardFace.Ace),
                new Card(CardSuite.Heart, CardFace.Ace),
                new Card(CardSuite.Diamond, CardFace.Ace),
                new Card(CardSuite.Spade, CardFace.Ace),
            };
            
            List<CardSuite> cardSuiteByPriority = new List<CardSuite>
            {
                CardSuite.Diamond,
                CardSuite.Heart,
                CardSuite.Club,
                CardSuite.Spade
            };
            
            //Act
            CardRule cardRule = new CardRule(cardSuiteByPriority);
            ICard winningCard = cardRule.GetWinningCard(cards);

            //Assert
            winningCard.Suite.Should().Be(CardSuite.Diamond);
            winningCard.Face.Should().Be(CardFace.Ace);
        }

        [Test]
        public void CardRule_GetWinningCard_should_return_highest_value_diamond_card_when_multiple_cards_of_diamond_suit_provided()
        {
            //Arrange
            List<ICard> cards = new List<ICard>
            {
                new Card(CardSuite.Diamond, CardFace.Ace),
                new Card(CardSuite.Diamond, CardFace.Two),
                new Card(CardSuite.Diamond, CardFace.King),
                new Card(CardSuite.Diamond, CardFace.Queen),
            };

            List<CardSuite> cardSuiteByPriority = new List<CardSuite>
            {
                CardSuite.Diamond,
                CardSuite.Heart,
                CardSuite.Club,
                CardSuite.Spade
            };

            //Act
            CardRule cardRule = new CardRule(cardSuiteByPriority);
            ICard winningCard = cardRule.GetWinningCard(cards);

            //Assert
            winningCard.Suite.Should().Be(CardSuite.Diamond);
            winningCard.Face.Should().Be(CardFace.King);
        }

        [Test]
        public void CardRule_GetWinningCard_should_return_heart_card_with_heighest_face_when_no_diamond_card_is_present()
        {
            //Arrange
            List<ICard> cards = new List<ICard>
            {
                new Card(CardSuite.Club, CardFace.King),
                new Card(CardSuite.Heart, CardFace.Two),
                new Card(CardSuite.Spade, CardFace.King),
                new Card(CardSuite.Spade, CardFace.King),
            };

            List<CardSuite> cardSuiteByPriority = new List<CardSuite>
            {
                CardSuite.Diamond,
                CardSuite.Heart,
                CardSuite.Club,
                CardSuite.Spade
            };

            //Act
            CardRule cardRule = new CardRule(cardSuiteByPriority);
            ICard winningCard = cardRule.GetWinningCard(cards);

            //Assert
            winningCard.Suite.Should().Be(CardSuite.Heart);
            winningCard.Face.Should().Be(CardFace.Two);
        }

        [Test]
        public void CardRule_GetWinningCard_should_return_club_card_with_heighest_face_when_no_diamond_and_heart_cards_are_present()
        {
            //Arrange
            List<ICard> cards = new List<ICard>
            {
                new Card(CardSuite.Club, CardFace.Queen),
                new Card(CardSuite.Club, CardFace.Ace),
                new Card(CardSuite.Spade, CardFace.King),
                new Card(CardSuite.Spade, CardFace.King),
            };

            List<CardSuite> cardSuiteByPriority = new List<CardSuite>
            {
                CardSuite.Diamond,
                CardSuite.Heart,
                CardSuite.Club,
                CardSuite.Spade
            };

            //Act
            CardRule cardRule = new CardRule(cardSuiteByPriority);
            ICard winningCard = cardRule.GetWinningCard(cards);

            //Assert
            winningCard.Suite.Should().Be(CardSuite.Club);
            winningCard.Face.Should().Be(CardFace.Queen);
        }

        [Test]
        public void CardRule_GetWinningCard_should_return_club_spead_with_heighest_face_when_no_diamond_heart_and_club_cards_are_present()
        {
            //Arrange
            List<ICard> cards = new List<ICard>
            {
                new Card(CardSuite.Spade, CardFace.Queen),
                new Card(CardSuite.Spade, CardFace.Ace),
                new Card(CardSuite.Spade, CardFace.King),
                new Card(CardSuite.Spade, CardFace.Jack),
            };

            List<CardSuite> cardSuiteByPriority = new List<CardSuite>
            {
                CardSuite.Diamond,
                CardSuite.Heart,
                CardSuite.Club,
                CardSuite.Spade
            };

            //Act
            CardRule cardRule = new CardRule(cardSuiteByPriority);
            ICard winningCard = cardRule.GetWinningCard(cards);

            //Assert
            winningCard.Suite.Should().Be(CardSuite.Spade);
            winningCard.Face.Should().Be(CardFace.King);
        }
    }
}