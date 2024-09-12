using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InputSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class InputStatusMessage : MonoBehaviour
    {
        [SerializeField] private InputController inputController;
        
        [Header("Message Setting")]
        [SerializeField] private int timeOnScreen;
        [SerializeField] private Color enabledColor;
        [SerializeField] private Color disabledColor;
        [SerializeField] private string enabledText;
        [SerializeField] private string disabledText;

        private TMP_Text _tmpText;
        private CancellationTokenSource _textDisappearCts;

        private void Awake()
        {
            _tmpText = GetComponent<TMP_Text>();
            inputController.OnInputStatusChanged += ShowMessage;
            gameObject.SetActive(false);
            _textDisappearCts = new();
        }

        private void OnDestroy()
        {
            inputController.OnInputStatusChanged -= ShowMessage;
        }

        private void ShowMessage(bool inputEnabled)
        {
            if (gameObject.activeSelf)
            {
                _textDisappearCts.Cancel();
                _textDisappearCts.Dispose();
                _textDisappearCts = new();
            }
            
            gameObject.SetActive(true);
            if (inputEnabled)
            {
                _tmpText.text = enabledText;
                _tmpText.color = enabledColor;
                StayOnScreenAsync(_textDisappearCts.Token).Forget();
            }
            else
            {
                _tmpText.text = disabledText;
                _tmpText.color = disabledColor;
                StayOnScreenAsync(_textDisappearCts.Token).Forget();
            }
        }

        private async UniTask StayOnScreenAsync(CancellationToken token)
        {
            await UniTask.Delay(timeOnScreen, cancellationToken: token);
            gameObject.SetActive(false);
        }
    }
}
