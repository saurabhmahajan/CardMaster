using System.Collections.Generic;

namespace CardMaster.Business.Interfaces
{
    public interface IGameSettings
    {
        List<ICardPlayer> Players { get; }
        CardDeck CardDeck { get; }
        int NoOfRounds { get; }
    }
}