using System;
using UnityEngine;

namespace _Source.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [field:SerializeField] public float Speed { get; private set; }
        [field:SerializeField] public float RotationSpeed { get; private set; }
        [field:SerializeField] public float JumpForce { get; private set; }
        public Rigidbody Rb { get; private set; }
        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
        }
    }
}