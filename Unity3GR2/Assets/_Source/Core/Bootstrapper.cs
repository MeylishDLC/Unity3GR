using System;
using GameResources;
using InputSystem;
using ScoreSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private ClickableItem clickableItem;
        [SerializeField] private ScoreView scoreView;

        private Game _game;
        private Score _score;
        private void Awake()
        {
            _score = new Score();
            _game = new Game(_score);
            clickableItem.Construct(_score);
            scoreView.Bind(_score);
            _game.StartGame();
            inputListener.Construct(_game);
        }
    }
}
