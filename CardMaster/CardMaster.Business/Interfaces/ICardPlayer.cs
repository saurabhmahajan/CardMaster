using System.Collections.Generic;

namespace CardMaster.Business.Interfaces
{
    public interface ICardPlayer
    {
        void AcceptCard(ICard card);
        ICard DrawCard();
        void ResetCard();
        void DistributeCards(CardDeck deck, List<ICardPlayer> players);
    }
}