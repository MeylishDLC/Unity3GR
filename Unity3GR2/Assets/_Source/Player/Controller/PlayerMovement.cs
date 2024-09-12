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
            rb.transform.position += rb.transform.TransformDirection(direction) * (speed * Time.deltaTime);
        }
        public void Rotate(float rotationSpeed, Rigidbody rb, float direction)
        {
            var rotationAmount = direction * rotationSpeed * Time.deltaTime;
            var deltaRotation = Quaternion.Euler(0, rotationAmount, 0);
            var targetRotation = rb.rotation * deltaRotation;
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        }

    }
}