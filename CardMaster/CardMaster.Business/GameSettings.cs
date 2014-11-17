using System.Collections.Generic;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class GameSettings : IGameSettings
    {
        public GameSettings(List<ICardPlayer> players, CardDeck cardDeck, int noOfRounds)
        {
            NoOfRounds = noOfRounds;
            CardDeck = cardDeck;
            Players = players;
        }

        public List<ICardPlayer> Players { get; private set; }
        public CardDeck CardDeck { get; private set; }
        public int NoOfRounds { get; private set; }
    }
}