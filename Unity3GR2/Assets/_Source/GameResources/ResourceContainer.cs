using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameResources
{
    public class ResourceContainer
    {
        private const int initialResourceValue = 0;
        private static ResourceContainer _instance;
        public static ResourceContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResourceContainer();
                }
                return _instance;
            }
        }
        private Dictionary<ResourceTypes, Resource> _resources = new();
        private ResourceContainer() { }
        public int GetResourceAmount(ResourceTypes resourceType)
        {
            CheckResourcesInitialized();
            return _resources[resourceType].Amount;
        }
        public void AddToResourceAmount(ResourceTypes resourceType, int amount)
        {
            CheckResourcesInitialized();
            _resources[resourceType].SetResourceAmount(amount);
        }
        private void InitializeResources(int initialResourceAmount)
        {
            for (int i = 0; i < Enum.GetValues(typeof(ResourceTypes)).Length; i++)
            {
                var res = new Resource((ResourceTypes)i, initialResourceAmount);
                _resources.Add((ResourceTypes)i, res);
            }
        }
        private void CheckResourcesInitialized()
        {
            if (_resources.Count == 0)
            {
                InitializeResources(initialResourceValue);
            }
        }
    }
}