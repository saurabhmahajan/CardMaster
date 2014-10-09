using System;
using System.Collections.Generic;
using System.Linq;

namespace CardMaster.Business
{
    public class CardDeck
    {
        private const int CardDeckCapacity = 52;

        private readonly IDeckShuffler _deckShuffler;

        #region Private Members

        private IList<Card> CreateCardDeck()
        {
            var cards = new List<Card>(CardDeckCapacity);

            foreach (var cardSuite in Enum.GetNames(typeof(CardSuite)))
            {
                foreach (var cardFace in Enum.GetNames(typeof(CardFace)))
                {
                    cards.Add(new Card((CardSuite)Enum.Parse(typeof(CardSuite), cardSuite),
                        (CardFace)Enum.Parse(typeof(CardFace), cardFace)));
                }
            }

            return cards;
        }

        #endregion

        #region Public Members

        public IList<Card> Cards { get; set; }

        public CardDeck(IDeckShuffler deckShuffler)
        {
            _deckShuffler = deckShuffler;
            Cards = CreateCardDeck();
        }

        public CardDeck() : this(new DefaultDeckShuffler()) 
        {
        }

        public void Shuffle()
        {
            Cards = _deckShuffler.Shuffle(Cards);
        }

        #endregion

    }
}