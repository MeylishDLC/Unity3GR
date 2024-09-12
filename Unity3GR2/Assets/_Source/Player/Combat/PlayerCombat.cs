using UnityEngine;

namespace Player.Combat
{
    public class PlayerCombat
    {
        public void Shoot(Bullet bulletPrefab, Rigidbody playerRb)
        {
            var bullet = Object.Instantiate(bulletPrefab, playerRb.position, playerRb.rotation);

            var bulletRb = bullet.GetComponent<Rigidbody>();
            var shootDirection = playerRb.transform.forward;
            
            bulletRb.AddForce(shootDirection * bullet.Speed, ForceMode.Impulse);
        }
    }
}