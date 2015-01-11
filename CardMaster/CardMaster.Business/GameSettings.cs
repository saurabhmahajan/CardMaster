using System.Collections.Generic;
using CardMaster.Business.CardRules;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class GameSettings : IGameSettings
    {
        public GameSettings(CardDeck cardDeck, int noOfRounds, IWinningCardRule winningCardRule)
        {
            NoOfRounds = noOfRounds;
            WinningCardRule = winningCardRule;
            CardDeck = cardDeck;
        }

        public void DescreaseRoundCount()
        {
            NoOfRounds--;
        }

        public CardDeck CardDeck { get; private set; }
        public int NoOfRounds { get; private set; }
        public IWinningCardRule WinningCardRule { get; private set; }
    }
}