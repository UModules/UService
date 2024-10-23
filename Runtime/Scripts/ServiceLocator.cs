using System;
using System.Collections.Generic;
using UnityEngine;

namespace UService
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        /// <summary>
        /// Register an existing instance of a service.
        /// </summary>
        /// <typeparam name="IService">The type of the service to register.</typeparam>
        /// <param name="service">The service instance.</param>
        public static void RegisterService<IService>(IService service)
        {
            var type = typeof(IService);

            if (!_services.ContainsKey(type))
            {
                _services[type] = service;
                Debug.Log($"Service of type <color=cyan>{type.Name}</color> registered successfully.");
            }
            else
            {
                throw new InvalidOperationException($"Service of type <color=cyan>{type.Name}</color> is already registered.");
            }
        }

        /// <summary>
        /// Register a service by its type, with lazy instantiation.
        /// </summary>
        /// <typeparam name="IService">The interface or class to register and create.</typeparam>
        public static void RegisterService<IService>() where IService : class, new()
        {
            var type = typeof(IService);

            if (_services.ContainsKey(type))
            {
                throw new InvalidOperationException($"Service of type <color=cyan>{type.Name}</color> is already registered.");
            }

            if (typeof(MonoBehaviour).IsAssignableFrom(type))
            {
                // MonoBehaviour must be added to a GameObject, cannot instantiate it with 'new'
                var gameObject = new GameObject(type.Name);
                var instance = gameObject.AddComponent(type);
                _services[type] = instance;
                Debug.Log($"Service of type <color=cyan>{type.Name}</color> registered as a MonoBehaviour and attached to a new GameObject.");
            }
            else
            {
                try
                {
                    var instance = new IService();
                    _services[type] = instance;
                    Debug.Log($"Service of type <color=cyan>{type.Name}</color> registered and instantiated successfully.");
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Failed to instantiate service of type <color=cyan>{type.Name}</color>.", ex);
                }
            }
        }

        /// <summary>
        /// Retrieve a service, or lazily instantiate it if it's a non-MonoBehaviour.
        /// </summary>
        /// <typeparam name="IService">The type of the service to retrieve.</typeparam>
        /// <returns>The service instance.</returns>
        public static IService GetService<IService>() where IService : class, new()
        {
            var type = typeof(IService);

            if (_services.TryGetValue(type, out var service))
            {
                return (IService)service;
            }
            else
            {
                RegisterService<IService>();
                return GetService<IService>();
            }

            // For MonoBehaviour types, throw an exception since they must be managed via Unity's GameObject system
            throw new InvalidOperationException($"Service of type <color=cyan>{type.Name}</color> is a MonoBehaviour and must be attached to a GameObject.");
        }

        /// <summary>
        /// Unregister a service if needed.
        /// </summary>
        /// <typeparam name="IService">The type of the service to unregister.</typeparam>
        public static void UnregisterService<IService>()
        {
            var type = typeof(IService);
            if (_services.ContainsKey(type))
            {
                _services.Remove(type);
                Debug.Log($"Service of type <color=cyan>{type.Name}</color> unregistered successfully.");
            }
            else
            {
                throw new InvalidOperationException($"Service of type <color=cyan>{type.Name}</color> is not registered.");
            }
        }
    }
}
