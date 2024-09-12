using UnityEngine;

namespace InputSystem
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        private bool _movementDisabled;
        private void Update()
        {
            ReadInputSwitch();
        }

        private void ReadInputSwitch()
        {
            if (Input.GetKeyDown(KeyCode.Return) && _movementDisabled)
            {
                DisableInput();
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && !_movementDisabled)
            {
                EnableInput();
            }
        }
        private void DisableInput()
        {
            inputListener.enabled = false;
            _movementDisabled = true;
            Debug.Log("Movement disabled");
        }
        private void EnableInput()
        {
            inputListener.enabled = true;
            _movementDisabled = false;
            Debug.Log("Movement enabled");
        }
    }
}
