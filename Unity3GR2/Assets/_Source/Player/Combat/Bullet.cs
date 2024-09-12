using UnityEngine;

namespace Player.Combat
{
    [RequireComponent(typeof(Collider))]
    public class Bullet: MonoBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public Vector3 Direction { get; private set; }
        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
        
    }
}