using ScoreSystem;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private const int _startScoreValue = 5;
        private const int _finishScoreValue = 0;
        
        private readonly Score _score;
        public Game(Score score)
        {
            _score = score;
        }
        public void StartGame()
        {
            Debug.Log("Game Started");
            _score.SetScoreValue(_startScoreValue);
        }
        public void FinishGame()
        {
            Debug.Log("Game Finished");
            _score.SetScoreValue(_finishScoreValue);
        }
    }
}