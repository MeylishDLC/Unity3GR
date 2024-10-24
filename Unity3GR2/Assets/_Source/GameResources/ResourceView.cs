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

            if (CheckIfTypeSupported(selectedResourceIndex))
            {
                TryAddResource((ResourceTypes)selectedResourceIndex, GetAddAmountValue());
            }
            else
            {
                throw new Exception($"Resource type {selectedResourceIndex} is not supported");
            }
            RefreshResourceViewValues();
        }
        private bool CheckIfTypeSupported(int typeIndex)
        {
            var enumType = typeof(ResourceTypes);
            var enumValues = Enum.GetValues(enumType);
            foreach (var value in enumValues)
            {
                if ((int)value == typeIndex)
                {
                    return true;
                }
            }
            return false;
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