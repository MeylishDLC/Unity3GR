using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace Services
{
    public class ResourceLoader<T> where T : ScriptableObject
    {
        private static ResourceLoader<T> _instance;

        public static ResourceLoader<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ResourceLoader<T>();
                }
                return _instance;
            }
        }
        
        private readonly Dictionary<Type, T> _resources = new();

        public bool TryLoadResource(string path, out T resource)
        {
            resource = default;
            var res = LoadResource(path);
            if (res == null)
            {
                return false;
            }
            
            resource = res as T;
            _resources.Add(typeof(T), resource);
            return true;
        }
        public bool TryGetResource(Type type, out T resource)
        {
            resource = default;
            return _resources.TryGetValue(type, out resource);
        }

        public void UnloadResource(T resource)
        {
            _resources.Remove(resource.GetType());
            Resources.UnloadAsset(resource);
        }
        private Object LoadResource(string path)
        {
            return Resources.Load(path);
        }
    }
}