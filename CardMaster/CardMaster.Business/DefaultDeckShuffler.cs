using System;
using System.Collections.Generic;
using System.Linq;

namespace CardMaster.Business
{
    public class DefaultDeckShuffler : IDeckShuffler
    {
        public IList<Card> Shuffle(IList<Card> cards)
        {
            Random random = new Random();
            Card[] temporaryCards = new Card[cards.Count];

            foreach (var card in cards)
            {
                int nextPosition = random.Next(0, 52);

                while (temporaryCards[nextPosition] != null)
                {
                    nextPosition =
                        temporaryCards.Count(c => c == null) > 2 ?
                            random.Next(0, 51) :
                            Array.FindIndex(temporaryCards, tCard => tCard == null);
                }

                temporaryCards[nextPosition] = card;
            }

            return temporaryCards.ToList();
        }
    }
}