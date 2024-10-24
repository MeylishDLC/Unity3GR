using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ResourceSystem.Data;
using Services;
using UnityEngine;

namespace ResourceSystem
{
    public class ResourceDataService
    {
        private static ResourceDataService _instance;

        public static ResourceDataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResourceDataService();
                }
                return _instance;
            }
        }
        private ResourcesDataSO _resourcesDataSO;
        private ResourcesDataSO ResourcesDataSo
        {
            get
            {
                if (_resourcesDataSO == null)
                {
                    if (ResourceLoader<ResourcesDataSO>.Instance.TryGetResource(typeof(ResourcesDataSO),
                            out var res))
                    {
                        _resourcesDataSO = res;
                    }
                    else
                    {
                        ResourceLoader<ResourcesDataSO>.Instance.TryLoadResource("ResourcesDataSO", out _resourcesDataSO);
                    }
                }
                return _resourcesDataSO;
            }
        }
        public float GetEnabledTime(ResourceType resourceType)
        {
            if (ResourcesDataSo.TryGetEnableTime(resourceType, out var enableTime))
            {
                return enableTime;
            }
            return 0;
        }
        public float GetDisabledTime(ResourceType resourceType)
        {
            if (ResourcesDataSo.TryGetDisableTime(resourceType, out var disableTime))
            {
                return disableTime;
            }
            return 0;
        }
        
    }
}