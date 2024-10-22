using System;
using System.Threading;
using Core;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainGameUI: MonoBehaviour
    {
        [SerializeField] private TMP_Text timeText;
        [SerializeField] private Image gameOverPanel;
        [SerializeField] private Button restartButton;

        private Game _game;
        private float _currentTime;
        public void Construct(Game game)
        {
            _game = game;
            _game.OnGameEnd += ShowGameOverPanel;
            restartButton.onClick.AddListener(RestartGame);
        }
        private void Start()
        {
            gameOverPanel.gameObject.SetActive(false);
            timeText.text = 0.ToString();
        }
        private void OnDestroy()
        {
            _game.OnGameEnd -= ShowGameOverPanel;
        }
        public async UniTask StartTimeTracking(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                _currentTime += Time.deltaTime; 
                var minutes = Mathf.FloorToInt(_currentTime / 60);
                var seconds = Mathf.FloorToInt(_currentTime % 60);

                timeText.text = $"{minutes:D2}:{seconds:D2}";
                await UniTask.Yield(PlayerLoopTiming.Update);
            }
        }
        private void ShowGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
        }
        private void RestartGame()
        {
            restartButton.interactable = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}