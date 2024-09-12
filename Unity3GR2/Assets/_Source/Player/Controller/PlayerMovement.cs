using UnityEngine;

namespace Player.Controller
{
    public class PlayerMovement
    {
        public void Jump(float force, Rigidbody rb)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
        public void Move(float speed, Rigidbody rb, Vector3 direction)
        {
            var playerTransform = rb.transform;
            playerTransform.position += playerTransform.TransformDirection(direction) * (speed * Time.deltaTime);
        }
        public void Rotate(float rotationSpeed, Rigidbody rb, float direction)
        {
            var rotationAmount = direction * rotationSpeed * Time.deltaTime;
            var deltaRotation = Quaternion.Euler(0, rotationAmount, 0);

            var playerRotation = rb.rotation;
            var targetRotation = playerRotation * deltaRotation;
            rb.MoveRotation(Quaternion.RotateTowards(playerRotation, targetRotation, rotationSpeed * Time.deltaTime));
        }

    }
}