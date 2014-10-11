using System.Collections.Generic;
using System.Linq;

namespace CardMaster.Business
{
    public class CardRule
    {
        private readonly List<CardSuite> _cardSuiteByPriority;

        public CardRule(List<CardSuite> cardSuiteByPriority)
        {
            _cardSuiteByPriority = cardSuiteByPriority;
        }

        public ICard GetWinningCard(List<ICard> cards)
        {
           foreach (var cardSuite in _cardSuiteByPriority)
            {
                List<ICard> probableWinnerCards = cards.Where(c => c.Suite == cardSuite).ToList();
                ICard card = probableWinnerCards.SingleOrDefault(e => e.Face == probableWinnerCards.Max(x => x.Face));
                if (card != null)
                {
                    return card;
                }   
            }

            //reached to an end and no valid card found, throwing exception as this is not an acceptable case
            throw new CardNotFoundException("No valid card found");
        }
    }
}