using System;

namespace CardMaster.Business.Exceptions
{
    public class NotEnoughPlayersException : Exception
    {
        public NotEnoughPlayersException(string message)
            : base(message)
        {

        }
    }
}