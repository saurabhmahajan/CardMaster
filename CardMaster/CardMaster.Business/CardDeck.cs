using System;
using System.Collections.Generic;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class CardDeck
    {
        private const int CardDeckCapacity = 52;

        private readonly IDeckShuffler _deckShuffler;

        #region Private Members

        private IList<ICard> CreateCardDeck()
        {
            var cards = new List<ICard>(CardDeckCapacity);

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

        public IList<ICard> Cards { get; set; }

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