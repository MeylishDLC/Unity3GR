using Player.Controller;
using UnityEngine;

namespace InputSystem
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
            ReadShoot();
        }

        private void ReadJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerInvoker.InvokeJump();
            }
        }

        private void ReadMovement()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _playerInvoker.InvokeMove(Vector3.forward);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _playerInvoker.InvokeMove(Vector3.back);
            }
        }

        private void ReadRotation()
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                var direction = Input.GetAxis("Horizontal");
                if (direction != 0)
                {
                    _playerInvoker.InvokeRotate(direction);
                }
            }
        }

        private void ReadDisableMovement()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                _movementDisabled = true;
                Debug.Log("Movement disabled");
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _movementDisabled = false;
                Debug.Log("Movement enabled");
            }
        }

        private void ReadShoot()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _playerInvoker.InvokeShoot();
            }
        }
    }
}
