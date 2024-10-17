using System;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreView: MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        private Score _score;

        public void Bind()
        {
            _score.OnScoreUpdated += RefreshScore;
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