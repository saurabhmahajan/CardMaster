using System;

namespace CardMaster.Business.Exceptions
{
    public class CardNotFoundException : Exception
    {
        public CardNotFoundException(string message):base(message) { }
    }
}