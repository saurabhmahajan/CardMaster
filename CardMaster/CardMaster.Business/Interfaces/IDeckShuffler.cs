using System.Collections.Generic;

namespace CardMaster.Business.Interfaces
{
    public interface IDeckShuffler
    {
        IList<ICard> Shuffle(IList<ICard> cards);
    }
}