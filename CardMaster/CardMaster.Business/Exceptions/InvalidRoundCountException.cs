using System;

namespace CardMaster.Business.Exceptions
{
    public class InvalidRoundCountException : Exception
    {
        public InvalidRoundCountException(string message):base(message) {}
    }
}