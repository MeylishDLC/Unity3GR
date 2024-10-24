using ResourceSystem.Data;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace ResourceSystem
{
    public class ResourceViewService
    {
        private static ResourceViewService _instance;

        public static ResourceViewService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResourceViewService();
                }
                return _instance;
            }
        }

        private ResourcesViewDataSO _viewData;
        private ResourcesViewDataSO ViewDataSo
        {
            get
            {
                if (_viewData == null)
                {
                    if (ResourceLoader<ResourcesViewDataSO>.Instance.TryGetResource(typeof(ResourcesViewDataSO),
                            out var data))
                    {
                        _viewData = data;
                    }
                    else
                    {
                        ResourceLoader<ResourcesViewDataSO>.Instance.TryLoadResource("ResourcesViewDataSo", out _viewData);
                    }
                }
                return _viewData;
            }
        }
        public void SetEnabledIcon(Image resourceIcon, ResourceType resourceType)
        {
            if (ViewDataSo.TryGetEnableIcon(resourceType, out var enableIcon))
            {
                resourceIcon.sprite = enableIcon;
            }
        }
        public void SetDisabledIcon(Image resourceIcon, ResourceType resourceType)
        {
            if (ViewDataSo.TryGetDisableIcon(resourceType, out var disableIcon))
            {
                resourceIcon.sprite = disableIcon;
            }
        }
    }
}