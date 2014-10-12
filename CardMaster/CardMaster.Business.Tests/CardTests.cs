using CardMaster.Business.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace CardMaster.Business.Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void Card_should_have_valid_value_and_suite()
        {
            //Arrange
            Card card = new Card(CardSuite.Diamond, CardFace.Ace);

            //Act

            //Assert
            card.Suite.Should().NotBe(0);
            card.Face.Should().NotBe(0);
        }

        [Test]
        public void Card_should_show_values_that_are_assigned_when_card_created()
        {
            //Arrange
            Card card = new Card(CardSuite.Heart, CardFace.Queen);

            //Act

            //Assert
            card.Suite.Should().Be(CardSuite.Heart);
            card.Face.Should().Be(CardFace.Queen);
        }
    }
}
