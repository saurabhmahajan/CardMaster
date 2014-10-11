namespace CardMaster.Business
{
    public class Card : ICard
    {
        public Card(CardSuite suite, CardFace face)
        {
            Face = face;
            Suite = suite;
        }

        public CardSuite Suite { get; private set; }
        public CardFace Face { get; private set; }
    }
}