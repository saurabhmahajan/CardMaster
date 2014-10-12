using System.Linq;
using CardMaster.Business.Enums;
using CardMaster.Business.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CardMaster.Business.Tests
{
    [TestFixture]
    public class CardDeckTests
    {
        [Test]
        public void CardDeck_should_have_no_more_than_52_cards()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();

            //Act

            //Assert
            cardDeck.Cards.Count.Should().Be(52);
        }

        [Test] public void CardDeck_should_have_all_unique_cards()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();

            //Act
            var duplicateCards = cardDeck.Cards.GroupBy(c => new {c.Face, c.Suite}).Where(c => c.Count() > 1).Select(c => c);

            //Assert
            duplicateCards.Count().Should().Be(0);
        }

        [Test]
        public void CardDeck_should_have_13_hearts()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();

            //Act
            IEnumerable<ICard> hearts = cardDeck.Cards.Where(c => c.Suite == CardSuite.Heart).Select(c => c);

            //Assert
            hearts.Count().Should().Be(13);
        }

        [Test]
        public void CardDeck_should_have_13_clubs()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();

            //Act
            IEnumerable<ICard> clubs = cardDeck.Cards.Where(c => c.Suite == CardSuite.Club).Select(c => c);

            //Assert
            clubs.Count().Should().Be(13);
        }

        [Test]
        public void CardDeck_should_have_13_diamonds()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();

            //Act
            IEnumerable<ICard> diamonds = cardDeck.Cards.Where(c => c.Suite == CardSuite.Diamond).Select(c => c);

            //Assert
            diamonds.Count().Should().Be(13);
        }

        [Test]
        public void CardDeck_should_have_13_spades()
        {
            //Arrange
            CardDeck cardDeck = new CardDeck();

            //Act
            IEnumerable<ICard> spades = cardDeck.Cards.Where(c => c.Suite == CardSuite.Spade).Select(c => c);

            //Assert
            spades.Count().Should().Be(13);
        }

        [Test]
        public void CardDeck_when_shuffeled_should_not_keep_3_consecutive_card_of_same_suite_together()
        {
            //Arrange
            ICard lastToLastCard = null, lastCard = null;
            bool areThreeCardsofSameSuiteInSquence = false;
            CardDeck cardDeck = new CardDeck();

            //Act
            cardDeck.Shuffle();

            //Assert
            foreach (ICard card in cardDeck.Cards)
            {
                if (lastToLastCard != null && lastCard != null && card != null)
                {
                    if (lastToLastCard.Suite == lastCard.Suite && lastCard.Suite == card.Suite)
                    {
                        areThreeCardsofSameSuiteInSquence = true;
                        break;
                    }
                }
                else
                {
                    lastToLastCard = lastCard;
                    lastCard = card;
                }
            }

            areThreeCardsofSameSuiteInSquence.Should().Be(false);
        }


    }
}