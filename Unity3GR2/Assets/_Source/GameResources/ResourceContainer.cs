using System;
using UnityEngine;

namespace GameResources
{
    public class ResourceContainer: MonoBehaviour
    {
        public static ResourceContainer Instance {get; private set;}
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}