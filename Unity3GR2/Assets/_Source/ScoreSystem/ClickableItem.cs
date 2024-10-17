using System;
using System.Security.Cryptography;
using UnityEngine;

namespace ScoreSystem
{
    public class ClickableItem: MonoBehaviour
    {
        private Score _score;

        public void Construct(Score score)
        {
            _score = score;
        }
        private void OnMouseDown()
        {
            _score.AddScore(-1);
        }
    }
}