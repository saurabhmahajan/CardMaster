using System;
using System.Collections.Generic;
using System.Linq;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    /// <summary>
    /// Desc shuffler which does not allow 3 consecutive cards of same suite.
    /// </summary>
    public class DefaultDeckShuffler : IDeckShuffler
    {
        public IEnumerable<ICard> Shuffle(ICollection<ICard> deck)
        {
            Random random = new Random();
            
            int countOfCardsInDeck = deck.Count;

            ICard[] temporaryDeck = new ICard[countOfCardsInDeck];

            foreach (var card in deck)
            {
                int probableEmptyPosition = random.Next(0, countOfCardsInDeck);

                bool isValidEmptyPosition = IsCardAtGivenPostionEmpty(temporaryDeck, probableEmptyPosition);

                if (!isValidEmptyPosition)
                {
                    probableEmptyPosition = GetNextValidEmptyPosition(temporaryDeck, random);
                }

                temporaryDeck[probableEmptyPosition] = card;
            }

            return temporaryDeck.ToList();
        }

        private int GetNextValidEmptyPosition(ICard[] temporaryDeck, Random random)
        {
            int deckLength = temporaryDeck.Count();

            if (temporaryDeck.Count(c => c == null) < 2) // No fun finding an empty space randomly if empty spaces are less than 2
            {
                return Array.FindIndex(temporaryDeck, tCard => tCard == null);
            }
            
            int probableEmptyPosition = 0;
            
            while (!IsCardAtGivenPostionEmpty(temporaryDeck, probableEmptyPosition))
            {
                probableEmptyPosition = random.Next(0, deckLength);
            }

            return probableEmptyPosition;
        }

        private bool IsCardAtGivenPostionEmpty(ICard[] deck, int position)
        {
            return deck[position] == null;
        }
    }
}