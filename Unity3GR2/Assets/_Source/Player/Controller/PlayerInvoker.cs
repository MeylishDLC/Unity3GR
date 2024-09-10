using UnityEngine;

namespace _Source.Player.Controller
{
    public class PlayerInvoker
    {
        private PlayerMovement _playerMovement;
        private Player _player;

        //dependency
        public PlayerInvoker(Player player)
        {
            _playerMovement = new();
            _player = player;
        }
        public void InvokeJump()
        {
            _playerMovement.Jump(_player.JumpForce, _player.Rb);
        }
        public void InvokeMove(Vector3 direction)
        {
            _playerMovement.Move(_player.Speed, _player.Rb, direction);
        }
        public void InvokeRotate(float direction)
        {
            _playerMovement.Rotate(_player.RotationSpeed, _player.Rb, direction);
        }
        
    }
}