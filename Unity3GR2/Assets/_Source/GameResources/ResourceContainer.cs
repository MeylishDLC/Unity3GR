using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameResources
{
    /*Создайте enum с несколькими видами ресурсов (например, Wood, Stone, Gold и т.д.)
     Создайте класс Resource, который будет хранить тип ресурса (тот самый enum) и количество ресурса (целочисленное). 
     Создайте класс-синглтон, который будет инициализировать пул экземпляров класса Resource и хранить в словаре, из которого по ключу в виде типа ресурса можно получить экземпляр класса ресурса.
     Создайте метод в классе-синглтоне, который будет получать тип ресурса и возвращать количество этого ресурса. 
     Создайте метод в классе-синглтоне, который будет получать тип ресурса и целочисленное значение и будет ресурсу соответствующего типа прибавлять переданное в метод значение.
     Ни один из выше описанных классов не является компонентом.Для обработки событий интерфейса, которые описаны далее, создайте необходимый(-е) компонент(-ы).
     Создайте в сцене InputField, принимающий целые числа; выпадающий список, представляющий описанный выше enum и кнопку с надписью Add.
     По нажатию кнопки Add в ресурс, тип которого выбран в выпадающем списке, должно прибавляться значение, записанное пользователем в InputField.
    
    Отрисуйте в верхней части экрана текущее состояние ResourceBank'a:
    - каждый ресурс в формате "название ресурса - количество этого ресурса" с помощью TMP
    - вызывайте перерисовку количества ресурсов в интерфейсе только тогда, когда количество ресурса действительно меняется*/
    public class ResourceContainer
    {
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
            _resources[resourceType].Amount += amount;
        }
        private void InitializeResources(int initialResourceValue)
        {
            for (int i = 0; i < Enum.GetValues(typeof(ResourceTypes)).Length; i++)
            {
                var res = new Resource((ResourceTypes)i, initialResourceValue);
                _resources.Add((ResourceTypes)i, res);
            }
        }
        private void CheckResourcesInitialized()
        {
            if (_resources.Count == 0)
            {
                InitializeResources(0);
            }
        }
    }
}