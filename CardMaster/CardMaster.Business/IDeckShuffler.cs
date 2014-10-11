using System.Collections.Generic;

namespace CardMaster.Business
{
    public interface IDeckShuffler
    {
        IList<ICard> Shuffle(IList<ICard> cards);
    }
}