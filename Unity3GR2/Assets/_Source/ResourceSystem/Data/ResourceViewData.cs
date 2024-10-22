using UnityEngine;

namespace ResourceSystem.Data
{
    [System.Serializable]
    public class ResourceViewData
    {
        
        [field:SerializeField] public ResourceType ResourceType { get; private set; }
        [field:SerializeField] public Sprite EnabledStateIcon { get; private set; }
        [field:SerializeField] public Sprite DisabledStateIcon { get; private set; }
    }
}