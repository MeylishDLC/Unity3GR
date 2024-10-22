using ResourceSystem.Data;
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
                    _viewData = Resources.Load("ResourcesViewDataSo") as ResourcesViewDataSO;
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