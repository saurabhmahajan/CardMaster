using System.Collections.Generic;

namespace CardMaster.Business.Interfaces
{
    public interface IDeckShuffler
    {
        IEnumerable<ICard> Shuffle(IEnumerable<ICard> cards);
    }
}