using Player.Combat;
using UnityEngine;

namespace Player.Controller
{
    public class PlayerInvoker
    {
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerCombat _playerCombat;
        private readonly Player _player;
        public PlayerInvoker(Player player)
        {
            _playerMovement = new();
            _playerCombat = new();
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

        public void InvokeShoot()
        {
            _playerCombat.Shoot(_player.BulletPrefab, _player.Rb);
        }
    }
}