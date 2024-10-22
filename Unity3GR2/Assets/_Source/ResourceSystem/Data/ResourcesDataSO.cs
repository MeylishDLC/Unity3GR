using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "ResourcesDataSO", menuName = "SO/ResourcesDataSO")]
    public class ResourcesDataSO: ScriptableObject
    {
        [field:SerializeField]public List<ResourceData> ResourcesDataList { get; private set; }

        public bool TryGetEnableTime(ResourceType resourceType, out float time)
        {
            time = 0f;
            foreach (var resourceData in ResourcesDataList)
            {
                if (resourceData.ResourceType == resourceType)
                {
                    time = resourceData.EnableTime;
                    return true;
                }
            }
            return false;
        }
        
        public bool TryGetDisableTime(ResourceType resourceType, out float time)
        {
            time = 0f;
            foreach (var resourceData in ResourcesDataList)
            {
                if (resourceData.ResourceType == resourceType)
                {
                    time = resourceData.DisableTime;
                    return true;
                }
            }
            return false;
        }
    }
}