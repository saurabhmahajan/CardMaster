using System.Collections.Generic;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class Player : ICardPlayer, IPlayer
    {
        private ICard _card;

        public Player(string name)
        {
            Name = name;
        }

        public void AcceptCard(ICard card)
        {
            _card = card;
        }

        public ICard DrawCard()
        {
            return _card;
        }

        public void ResetCard()
        {
            _card = null;
        }

        public void DistributeCards(CardDeck deck, List<ICardPlayer> players)
        {
            AcceptCard(deck.GetNextCard());

            foreach (var player in players)
            {
                player.AcceptCard(deck.GetNextCard());
            }
        }

        public string Name { get; private set; }
    }
}