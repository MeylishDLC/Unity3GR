using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameResources
{
    public class ResourceView: MonoBehaviour
    {
        [SerializeField] private TMP_Text[] texts;
        
        [SerializeField] private TMP_InputField resourceInputField;
        [SerializeField] private TMP_Dropdown resourceDropdown;
        [SerializeField] private Button addResourceButton;
        private void Awake()
        {
            addResourceButton.onClick.AddListener(OnAddButtonClick);
        }
        private void Start()
        {
            RefreshResourceViewValues();
        }
        private void OnAddButtonClick()
        {
            var selectedResourceIndex = resourceDropdown.value;
            switch (selectedResourceIndex)
            {
                case 0:
                    TryAddResource(0, GetAddAmountValue());
                    break;
                case 1:
                    TryAddResource((ResourceTypes)1, GetAddAmountValue());
                    break;
                case 2:
                    TryAddResource((ResourceTypes)2, GetAddAmountValue());
                    break;
                case 3:
                    TryAddResource((ResourceTypes)3, GetAddAmountValue());
                    break;
                default:
                    throw new Exception("Unsupported resource type selected.");
            }
            RefreshResourceViewValues();
        }
        private bool TryAddResource(ResourceTypes resourceType, int amountToAdd)
        {
            if (amountToAdd <= 0)
            {
                return false;
            }

            ResourceContainer.Instance.AddToResourceAmount(resourceType, amountToAdd);
            return true;
        }
        private int GetAddAmountValue()
        {
            var amount = Convert.ToInt32(resourceInputField.text);
            return amount;
        }
        private void RefreshResourceViewValues()
        {
            var index = 0;
            foreach (var tmpText in texts)
            {
                tmpText.text = $"{Enum.GetName(typeof(ResourceTypes), index)}: " +
                               $"{ResourceContainer.Instance.GetResourceAmount((ResourceTypes)index)}";
                index++;
            }
        }
    }
}