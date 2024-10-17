using System;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreView: MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private Score _score;
        
        public void Bind(Score score)
        {
            _score = score;
            _score.OnScoreUpdated += RefreshScore;
        }
        private void Start()
        {
            RefreshScore(_score.ScoreValue);
        }
        public void Expose()
        {
            _score.OnScoreUpdated -= RefreshScore;
        }
        private void RefreshScore(int scoreValue)
        {
            scoreText.text = $"Score: {scoreValue}";
        }
    }
}