using _Source.Player.Controller;
using UnityEngine;

namespace _Source.Input
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Player.Player player;
        private PlayerInvoker _playerInvoker;
        private bool _movementDisabled;
        private void Awake()
        {
            _playerInvoker = new PlayerInvoker(player);
        }

        void Update()
        {
            ReadDisableMovement();

            if (_movementDisabled)
            {
                return;
            }
            
            ReadMovement();
            ReadRotation();
            ReadJump();
        }

        private void ReadJump()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _playerInvoker.InvokeJump();
            }
        }

        private void ReadMovement()
        {
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                _playerInvoker.InvokeMove(Vector3.forward);
            }
            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                _playerInvoker.InvokeMove(Vector3.back);
            }
        }

        private void ReadRotation()
        {
            if (UnityEngine.Input.GetKey(KeyCode.D) || UnityEngine.Input.GetKey(KeyCode.A))
            {
                var direction = UnityEngine.Input.GetAxis("Horizontal");
                if (direction != 0)
                {
                    _playerInvoker.InvokeRotate(direction);
                }
            }
        }

        private void ReadDisableMovement()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
            {
                _movementDisabled = true;
                Debug.Log("Movement disabled");
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
            {
                _movementDisabled = false;
                Debug.Log("Movement enabled");
            }
        }
    }
}
