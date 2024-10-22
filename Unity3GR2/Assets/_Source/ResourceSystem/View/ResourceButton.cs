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
        [SerializeField] private ResourceType resourceType;
        [SerializeField] private Image resourceIconImage;

        private Button _button;
        private float _enabledTime;
        private float _disabledTime;
        
        private CancellationTokenSource _stopEnableTimeCts = new();
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(StopEnableState);
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
        private void StopEnableState()
        {
            ResourceTimerService.Instance.StopEnableTime(ref _stopEnableTimeCts);
        }
        public async UniTask StartResourceCycle(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await SetEnabledState(_stopEnableTimeCts.Token);
                await SetDisabledState(token);
            }
        }
        private async UniTask SetEnabledState(CancellationToken token)
        {
            ResourceViewService.Instance.SetEnabledIcon(resourceIconImage, resourceType);
            _button.interactable = true;

            await ResourceTimerService.Instance.StartEnableTimer(_enabledTime, token: token);
        }
        private async UniTask SetDisabledState(CancellationToken token)
        {
            ResourceViewService.Instance.SetDisabledIcon(resourceIconImage, resourceType);
            _button.interactable = false;
            
            await ResourceTimerService.Instance.StartDisableTimer(_disabledTime, token: token);
        }
    }
}