using System;
using System.Collections.Generic;
using System.Linq;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class DefaultDeckShuffler : IDeckShuffler
    {
        private const int MaxCardsInDeck = 52;

        public IEnumerable<ICard> Shuffle(IEnumerable<ICard> cards)
        {
            Random random = new Random();
         
            ICard[] temporaryDeck = new ICard[cards.Count()];

            foreach (var card in cards)
            {
                int probableEmptyPosition = random.Next(0, MaxCardsInDeck);

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
            if (temporaryDeck.Count(c => c == null) < 2) // No fun finding an empty space randomly if empty spaces are less than 2
            {
                return Array.FindIndex(temporaryDeck, tCard => tCard == null);
            }
            
            int probableEmptyPosition = 0;
            
            while (!IsCardAtGivenPostionEmpty(temporaryDeck, probableEmptyPosition))
            {
                probableEmptyPosition = random.Next(0, MaxCardsInDeck);
            }

            return probableEmptyPosition;
        }

        private bool IsCardAtGivenPostionEmpty(ICard[] deck, int position)
        {
            return deck[position] == null;
        }
    }
}