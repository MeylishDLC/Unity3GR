using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace InputSystem
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;

        public event Action<bool> OnInputStatusChanged;
        
        private bool _movementDisabled;
        private void Update()
        {
            ReadInputSwitch();
        }
        private void ReadInputSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Return) && !_movementDisabled)
            {
                DisableInput();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && _movementDisabled)
            {
                EnableInput();
            }
        }
        private void DisableInput()
        {
            inputListener.enabled = false;
            _movementDisabled = true;
            OnInputStatusChanged?.Invoke(false);
        }
        private void EnableInput()
        {
            inputListener.enabled = true;
            _movementDisabled = false;
            OnInputStatusChanged?.Invoke(true);
        }
    }
}
