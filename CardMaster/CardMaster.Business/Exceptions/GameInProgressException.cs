using System;

namespace CardMaster.Business.Exceptions
{
    public class GameInProgressException : Exception
    {
        public GameInProgressException(string message):base(message)
        {
            
        }
    }
}