using System.Collections.Generic;

namespace CardMaster.Business
{
    public interface IDeckShuffler
    {
        IList<Card> Shuffle(IList<Card> cards);
    }
}