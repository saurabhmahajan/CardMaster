using System;

namespace CardMaster.Business
{
    public class CardNotFoundException : Exception
    {
        public CardNotFoundException(string message):base(message) { }
    }
}