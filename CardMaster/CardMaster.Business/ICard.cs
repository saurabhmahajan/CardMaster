namespace CardMaster.Business
{
    public interface ICard
    {
        CardSuite Suite { get; }
        CardFace Face { get; }
    }
}