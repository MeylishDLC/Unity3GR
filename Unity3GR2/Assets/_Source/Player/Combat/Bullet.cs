using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Player.Combat
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet: MonoBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int LifetimeMilliseconds { get; private set; }

        private CancellationTokenSource stopLifetimeCts = new();
        private void OnEnable()
        {
            BeginLifetime(stopLifetimeCts.Token).Forget();
        }

        private void OnCollisionEnter()
        {
            if (stopLifetimeCts != null)
            {
                stopLifetimeCts.Cancel();
                stopLifetimeCts.Dispose();
            }
            Destroy(gameObject);
        }

        private async UniTask BeginLifetime(CancellationToken token)
        {
            await UniTask.Delay(LifetimeMilliseconds, cancellationToken: token);
            Destroy(gameObject);
        }
    }
}