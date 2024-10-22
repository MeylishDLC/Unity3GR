using System;
using System.Collections.Generic;
using ResourceSystem.View;
using UI;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<ResourceButton> resourceButtons;
        [SerializeField] private MainGameUI mainGameUI;
        private Game _game;
        private void Awake()
        {
            _game = new Game(resourceButtons, mainGameUI);
            mainGameUI.Construct(_game);
            _game.StartGame();
        }
    }
}
