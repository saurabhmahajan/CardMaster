using System;
using System.Collections.Generic;
using CardMaster.Business.Enums;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class CardDeck
    {
        private const int CardDeckCapacity = 52;

        private readonly IDeckShuffler _deckShuffler;

        #region Private Members

        private Queue<ICard> CreateCardDeck()
        {
            var cards = new Queue<ICard>(CardDeckCapacity);

            foreach (var cardSuite in Enum.GetNames(typeof(CardSuite)))
            {
                foreach (var cardFace in Enum.GetNames(typeof(CardFace)))
                {
                    cards.Enqueue(new Card((CardSuite)Enum.Parse(typeof(CardSuite), cardSuite),
                        (CardFace)Enum.Parse(typeof(CardFace), cardFace)));
                }
            }

            return cards;
        }

        #endregion

        #region Public Members

        public Queue<ICard> Cards { get; private set; }

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
            Cards = new Queue<ICard>(_deckShuffler.Shuffle(Cards));
        }

        #endregion

        public ICard GetNextCard()
        {
            return Cards.Dequeue();
        }
    }
}