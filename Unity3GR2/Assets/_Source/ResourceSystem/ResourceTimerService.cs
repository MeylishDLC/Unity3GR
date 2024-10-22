using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace ResourceSystem
{
    public partial class ResourceTimerService
    {
        public event Action OnResourceDestroyed;
        
        private static ResourceTimerService _instance;
        public static ResourceTimerService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResourceTimerService();
                }
                return _instance;
            }
        }

        public async UniTask StartEnableTimer(float enabledTime, CancellationToken token)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(enabledTime), cancellationToken: token);
                OnResourceDestroyed?.Invoke();
            }
            catch
            {
                //
            }
        }
        public async UniTask StartDisableTimer(float disabledTime, CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(disabledTime), cancellationToken: token);
        }
    }
}