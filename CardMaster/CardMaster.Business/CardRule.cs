using System.Collections.Generic;
using System.Linq;

namespace CardMaster.Business
{
    public class CardRule
    {
        public ICard GetWinningCard(List<ICard> cards)
        {
            List<ICard> probableWinnerCards = cards.Where(c => c.Suite == CardSuite.Diamond).ToList();
            ICard card = probableWinnerCards.SingleOrDefault(e => e.Face == probableWinnerCards.Max(x => x.Face));
            if (card != null)
            {
                return card;
            }

            probableWinnerCards = cards.Where(c => c.Suite == CardSuite.Heart).ToList();
            card = probableWinnerCards.SingleOrDefault(e => e.Face == probableWinnerCards.Max(x => x.Face));
            if (card != null)
            {
                return card;
            }

            probableWinnerCards = cards.Where(c => c.Suite == CardSuite.Club).ToList();
            card = probableWinnerCards.SingleOrDefault(e => e.Face == probableWinnerCards.Max(x => x.Face));
            if (card != null)
            {
                return card;
            }

            probableWinnerCards = cards.Where(c => c.Suite == CardSuite.Spade).ToList();
            card = probableWinnerCards.SingleOrDefault(e => e.Face == probableWinnerCards.Max(x => x.Face));
            if (card != null)
            {
                return card;
            }

            //reached to an end and no valid card found, throwing exception as this is not an acceptable case
            throw new CardNotFoundException("No valid card found");
        }
    }
}