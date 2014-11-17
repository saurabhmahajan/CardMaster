using System.Collections.Generic;
using CardMaster.Business.Enums;
using CardMaster.Business.Exceptions;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class Game
    {
        private ICardPlayer _cardDistributor;
        private int _roundCount;

        public Game(List<ICardPlayer> players)
        {
            Players = players;
        }

        public void Start()
        {
            ValidatePreconditions();
            UpdateGameStatusToStart();
            
            _cardDistributor = Players[0]; // Default selected
            

            for (int i = 0; i < _roundCount; i++)
            {
                _cardDistributor.DistributeCards(deck, Players);
            }

        }

        private void UpdateGameStatusToStart()
        {
            Status = GameStatus.InProgress;
        }

        public List<ICardPlayer> Players { get; private set; }

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

        public void SetRounds(int roundCount = 5)
        {
            if (Status == GameStatus.InProgress)
            {
                throw new GameInProgressException("Game is already in-progress");
            }

            _roundCount = roundCount;
        }

        public int GetRounds()
        {
            return _roundCount;
        }
    }
}