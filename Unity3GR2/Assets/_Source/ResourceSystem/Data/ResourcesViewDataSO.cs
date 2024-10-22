using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "ResourcesViewDataSo", menuName = "SO/ResourcesViewDataSO")]
    public class ResourcesViewDataSO: ScriptableObject
    {
        [field:SerializeField]public List<ResourceViewData> ResourcesViewDataList { get; private set; }

        public bool TryGetEnableIcon(ResourceType resourceType, out Sprite icon)
        {
            icon = null;

            foreach (var viewFata in ResourcesViewDataList)
            {
                if (viewFata.ResourceType == resourceType)
                {
                    icon = viewFata.EnabledStateIcon;
                    return true;
                }
            }
            return false;
        }
        
        public bool TryGetDisableIcon(ResourceType resourceType, out Sprite icon)
        {
            icon = null;

            foreach (var viewFata in ResourcesViewDataList)
            {
                if (viewFata.ResourceType == resourceType)
                {
                    icon = viewFata.DisabledStateIcon;
                    return true;
                }
            }
            return false;
        }
    }
}