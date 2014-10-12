using System.Collections.Generic;
using CardMaster.Business.Enums;
using CardMaster.Business.Exceptions;

namespace CardMaster.Business
{
    public class Game
    {
        public Game(List<Player> players)
        {
            Players = players;
        }

        public void Start()
        {
            ValidatePreconditions();
            Status = GameStatus.InProgress;
        }

        public List<Player> Players { get; private set; }

        public GameStatus Status { get; private set; }

        private void ValidatePreconditions()
        {
            if (Players.Count < 4)
            {
                throw new NotEnoughPlayersException("Minimum 4 players required to play the game");
            }

            if (Status == GameStatus.InProgress)
            {
                throw new GameInProgressException("Game is already in-progress");
            }
        }
    }
}