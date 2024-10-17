using System;

namespace ScoreSystem
{
    public class Score
    {
        public event Action<int> OnScoreUpdated; 
        public int ScoreValue { get; private set; }
        public void SetScoreValue(int value)
        {
            ScoreValue = value;
        }
        public void AddScore(int value)
        {
            ScoreValue += value;
            OnScoreUpdated?.Invoke(ScoreValue);
        }
    }
}