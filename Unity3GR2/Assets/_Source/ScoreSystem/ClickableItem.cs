
using UnityEngine;

namespace ScoreSystem
{
    public class ClickableItem: MonoBehaviour
    {
        [SerializeField] private int scoreToAdd;
        private Score _score;

        public void Construct(Score score)
        {
            _score = score;
        }
        private void OnMouseDown()
        {
            _score.AddScore(scoreToAdd);
        }
    }
}