using System.Collections.Generic;
using CardMaster.Business.CardRules;

namespace CardMaster.Business.Interfaces
{
    public interface IGameSettings
    {
        CardDeck CardDeck { get; }
        int NoOfRounds { get; }
        void DescreaseRoundCount();
        IWinningCardRule WinningCardRule { get; }
    }
}