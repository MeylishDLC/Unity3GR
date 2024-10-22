using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ResourceSystem.View;
using UI;
using UnityEngine;

namespace Core
{
    public class Game
    {
        public event Action OnGameEnd;

        private readonly List<ResourceButton> _resourceButtons;
        private readonly MainGameUI _mainGameUI;
        
        private readonly CancellationTokenSource _stopAllCyclesCts = new();
        private readonly CancellationTokenSource _stopTimeTrackingCts = new();
        public Game(List<ResourceButton> resourceButtons, MainGameUI mainGameUI)
        {
            _resourceButtons = resourceButtons;
            _mainGameUI = mainGameUI;
            Bind();
        }
        public void StartGame()
        {
            foreach (var resourceButton in _resourceButtons)
            {
                resourceButton.StartResourceCycle(_stopAllCyclesCts.Token).Forget();
            }
            _mainGameUI.StartTimeTracking(_stopTimeTrackingCts.Token).Forget();
        }
        private void EndGame()
        {
            if (_stopAllCyclesCts != null)
            {
                _stopAllCyclesCts.Cancel();
                _stopAllCyclesCts.Dispose();
            }
            if (_stopTimeTrackingCts != null)
            {
                _stopTimeTrackingCts.Cancel();
                _stopTimeTrackingCts.Dispose();
            }
            UnBind();
            OnGameEnd?.Invoke();
        }
        private void Bind()
        {
            foreach (var resourceButton in _resourceButtons)
            {
                resourceButton.OnResourceDestroyed += EndGame;
            }
        }
        private void UnBind()
        {
            foreach (var resourceButton in _resourceButtons)
            {
                resourceButton.OnResourceDestroyed -= EndGame;
            }
        }
    }
}