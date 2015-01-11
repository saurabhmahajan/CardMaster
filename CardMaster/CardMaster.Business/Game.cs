using System.Collections.Generic;
using System.Linq;
using CardMaster.Business.Enums;
using CardMaster.Business.Exceptions;
using CardMaster.Business.Interfaces;

namespace CardMaster.Business
{
    public class Game
    {
        public GameStatus Status { get; private set; }
 
        public Game(List<ICardPlayer> players, IGameSettings gameSettings)
        {
            _players = players;
            _gameSettings = gameSettings;
            _cardPalyerDictionary = new Dictionary<ICard, ICardPlayer>();
            _playerScoreDictionary = new Dictionary<ICardPlayer, int>();
        }

        public void Start()
        {
            ValidatePreconditions();
            UpdateGameStatusToStart();

            _cardDistributor = _players[0]; // Default selected as distributor

            while (_gameSettings.NoOfRounds > 0)
            {
                _cardDistributor.DistributeCards(_gameSettings.CardDeck, _players);

                foreach (var cardPlayer in _players)
                {
                    _cardPalyerDictionary.Add(cardPlayer.DrawCard(), cardPlayer);
                }

                ICard winningCard = _gameSettings.WinningCardRule.GetWinningCard(_cardPalyerDictionary.Keys.ToList());

                ICardPlayer winnerOfCurrentRound = _cardPalyerDictionary[winningCard];

                if (_playerScoreDictionary.ContainsKey(winnerOfCurrentRound))
                {
                    _playerScoreDictionary[winnerOfCurrentRound] = _playerScoreDictionary[winnerOfCurrentRound]++;
                }
                
                _gameSettings.DescreaseRoundCount();
            }

        }

        public int GetRounds()
        {
            return _gameSettings.NoOfRounds;
        }

        private readonly List<ICardPlayer> _players;
        private readonly IGameSettings _gameSettings;
        private ICardPlayer _cardDistributor;
        private readonly Dictionary<ICard, ICardPlayer> _cardPalyerDictionary;
        private readonly Dictionary<ICardPlayer, int> _playerScoreDictionary;

        private void UpdateGameStatusToStart()
        {
            Status = GameStatus.InProgress;
        }

        private void ValidatePreconditions()
        {
            if (_players.Count < 4)
            {
                throw new NotEnoughPlayersException("Minimum 4 players required to play the game");
            }

            if (Status == GameStatus.InProgress)
            {
                throw new GameInProgressException("Game is already in-progress");
            }

            if (_gameSettings.NoOfRounds <= 0)
            {
                throw new InvalidRoundCountException("Round count should be greater than 0");
            }
        }
    }
}