namespace CardMaster.Business.Interfaces
{
    public interface ICard
    {
        CardSuite Suite { get; }
        CardFace Face { get; }
    }
}