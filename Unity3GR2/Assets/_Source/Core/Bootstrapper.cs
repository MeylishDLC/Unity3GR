using System;
using InputSystem;
using ScoreSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener; 
        [SerializeField] private ClickableItem[] clickableItems;
        [SerializeField] private ScoreView scoreView;
        private Game _game;
        private Score _score;
        private void Awake()
        {
            _score = new Score();
            _game = new Game(_score);
            ConstructClickableItems();
            scoreView.Bind(_score);
            _game.StartGame();
            inputListener.Construct(_game);
        }
        private void ConstructClickableItems()
        {
            foreach (var clickableItem in clickableItems)
            {
                clickableItem.Construct(_score);
            }
        }
    }
}
