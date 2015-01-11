using System.Collections.Generic;
using System.Linq;
using CardMaster.Business.Enums;
using CardMaster.Business.Exceptions;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business.CardRules
{
    public interface IWinningCardRule
    {
        ICard GetWinningCard(List<ICard> cards);
    }

    public class SuitePriorityCardRule : IWinningCardRule
    {
        private readonly List<CardSuite> _cardSuitePriority;

        public SuitePriorityCardRule(List<CardSuite> cardSuitePriority)
        {
            _cardSuitePriority = cardSuitePriority;
        }

        public ICard GetWinningCard(List<ICard> cards)
        {
            foreach (var cardSuite in _cardSuitePriority)
            {
                List<ICard> probableWinningCards = cards.Where(c => c.Suite == cardSuite).ToList();

                ICard card = probableWinningCards.SingleOrDefault(e => e.Face == probableWinningCards.Max(x => x.Face));

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