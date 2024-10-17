using UnityEngine;

namespace Physics
{
    public class JellyVertex
    {
        public int ID { get; private set; }
        public Vector3 Position { get; private set; }
        private Vector3 Velocity;
        private Vector3 Force;

        public JellyVertex(int id, Vector3 pos)
        {
            ID = id;
            Position = pos;
        }

        public void Shake(Vector3 target, float mass, float stiffness, float damping)
        {
            Force = (target - Position) * stiffness;
            Velocity = (Velocity + Force / mass) * damping;
            Position += Velocity;
            if ((Velocity + Force + Force / mass).magnitude < 0.001f)
            {
                Position = target;
            }
        }
    }
}