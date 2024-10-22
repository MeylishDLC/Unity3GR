using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ResourceSystem.Data;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ResourceSystem.View
{
    public class ResourceButton: MonoBehaviour
    {
        public event Action OnResourceDestroyed;
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private Image resourceIconImage;

        private Button _button;
        private float _enabledTime;
        private float _disabledTime;
        
        private CancellationTokenSource _stopEnableTimeCts = new();
        /*В компоненте кнопки реализуйте следующую логику:
         При инициализации компонент получает данные о времени обогащения и распада своего ресурса
         При старте кнопка активна и у нее стоит иконка ресурса в активном состоянии
         При старте запускается таймер со временем распада, если таймер закончился, то объявляется проигрыш, игра останавливается
         При нажатии кнопки до истечения таймера распада запускается другой таймер — таймер обогащения
         В момент запуска обогащения иконка кнопки сменяется на иконку неактивного состояния ресурса, а кнопка становится некликабельной
         По истечении таймера обогащения снова ставится иконка ресурса в активном состоянии, кнопка становится кликабельной и запускается таймер распада
         Далее весь цикл сначала*/
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(StopEnableTime);
            GetResourceData();
            ResourceViewService.Instance.SetEnabledIcon(resourceIconImage, resourceType);
        }
        private void OnDestroy()
        {
            if (_stopEnableTimeCts != null)
            {
                _stopEnableTimeCts.Cancel();
                _stopEnableTimeCts.Dispose();
            }
        }
        private void GetResourceData()
        {
            _enabledTime = ResourceDataService.Instance.GetEnabledTime(resourceType);
            _disabledTime = ResourceDataService.Instance.GetDisabledTime(resourceType);
        }

        private void StopEnableTime()
        {
            _stopEnableTimeCts.Cancel();
            _stopEnableTimeCts.Dispose();
            _stopEnableTimeCts = new CancellationTokenSource();
        }
        public async UniTask StartResourceCycle(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await StartEnableTimeCountdown(_stopEnableTimeCts.Token);
                await StartDisableTimeCountdown(token);
            }
        }
        private async UniTask StartEnableTimeCountdown(CancellationToken token)
        {
            ResourceViewService.Instance.SetEnabledIcon(resourceIconImage, resourceType);
            _button.interactable = true;
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_enabledTime), cancellationToken: token);
                OnResourceDestroyed?.Invoke();
            }
            catch
            {
                //
            }
        }
        private async UniTask StartDisableTimeCountdown(CancellationToken token)
        {
            ResourceViewService.Instance.SetDisabledIcon(resourceIconImage, resourceType);
            _button.interactable = false;
            await UniTask.Delay(TimeSpan.FromSeconds(_disabledTime), cancellationToken: token);
        }
    }
}