using System;
using System.Collections.Generic;
using System.Linq;

namespace CardMaster.Business
{
    public class DefaultDeckShuffler : IDeckShuffler
    {
        private const int MaxCardsInDeck = 52;

        public IList<Card> Shuffle(IList<Card> cards)
        {
            Random random = new Random();
         
            Card[] temporaryCards = new Card[cards.Count];

            foreach (var card in cards)
            {
                int nextEmptyPosition = random.Next(0, MaxCardsInDeck);

                bool isValidEmptyPosition = IsCardAtGivenPostionEmpty(temporaryCards, nextEmptyPosition);

                if (!isValidEmptyPosition)
                {
                    nextEmptyPosition = GetNextValidEmptyPosition(temporaryCards, random);
                }

                temporaryCards[nextEmptyPosition] = card;
            }

            return temporaryCards.ToList();
        }

        private int GetNextValidEmptyPosition(Card[] temporaryCards, Random random)
        {
            if (temporaryCards.Count(c => c == null) < 2) // No fun finding an empty space randomly if empty spaces are less than 2
            {
                return Array.FindIndex(temporaryCards, tCard => tCard == null);
            }
            
            int nextEmptyPosition = 0;
            
            while (!IsCardAtGivenPostionEmpty(temporaryCards, nextEmptyPosition))
            {
                nextEmptyPosition = random.Next(0, MaxCardsInDeck);
            }

            return nextEmptyPosition;
        }

        private bool IsCardAtGivenPostionEmpty(Card[] deck, int position)
        {
            return deck[position] == null;
        }
    }
}