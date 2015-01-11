using System.Collections.Generic;

namespace CardMaster.Business.Interfaces
{
    public interface IDeckShuffler
    {
        IEnumerable<ICard> Shuffle(ICollection<ICard> deck);
    }
}