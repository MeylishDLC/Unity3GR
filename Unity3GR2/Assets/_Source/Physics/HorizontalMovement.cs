using UnityEngine;

namespace Physics
{
    public class HorizontalMovement: MonoBehaviour
    {
        [SerializeField] private float speed = 100f;

        private HingeJoint hingeJoint;
        private JointMotor motor;

        private void Start()
        {
            hingeJoint = GetComponent<HingeJoint>();
            motor = hingeJoint.motor;
            motor.force = 1000;
        }

        private void Update()
        {
            if (hingeJoint.angle >= hingeJoint.limits.max)
            {
                motor.targetVelocity = -speed;
            }
            else if (hingeJoint.angle <= hingeJoint.limits.min)
            {
                motor.targetVelocity = speed;
            }

            hingeJoint.motor = motor;
        }
    }
}