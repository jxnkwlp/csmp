using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TinyIoC;

namespace CSMP.Agent.Dependency
{
    /// <summary>
    ///  DI Service
    /// </summary>
    public static class DependencyService
    {
        private static readonly TinyIoCContainer _container = TinyIoCContainer.Current;

        static DependencyService()
        {
            _container.AutoRegister();

        }

        /// <summary>
        ///  注册
        /// </summary> 
        public static void Register<TServiceType>(string name = null) where TServiceType : class
        {
            _container.Register<TServiceType>(name);
        }

        /// <summary>
        ///  注册
        /// </summary> 
        public static void Register<TServiceType>(Func<TServiceType> implFunc) where TServiceType : class
        {
            _container.Register((_1, _2) => implFunc());
        }

        /// <summary>
        ///  注册
        /// </summary> 
        public static void Register<TServiceType, TImplementationType>(string name = null)
            where TServiceType : class
            where TImplementationType : class, TServiceType
        {
            _container.Register<TServiceType, TImplementationType>(name);
        }

        /// <summary>
        ///  注册
        /// </summary> 
        public static void Register(Type serviceType, Type implementationType, string name = null)
        {
            _container.Register(serviceType, implementationType, name);
        }

        /// <summary>
        ///  注册
        /// </summary> 
        public static void RegisterTypes<TServiceType>() where TServiceType : class
        {
            var list = GetTypes().Where(t => typeof(TServiceType).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsInterface);
            _container.RegisterMultiple(typeof(TServiceType), list);
        }

        /// <summary>
        ///  注册
        /// </summary> 
        public static void RegisterTypes(Type serviceType)
        {
            if (serviceType.IsGenericType)
            {
                var g = serviceType.GetGenericTypeDefinition();

                var list = GetTypes().Where(t => t.IsClass && !t.IsAbstract && !t.IsInterface);

                var result = from t in list
                             from i in t.GetInterfaces()
                             where
                             (t.BaseType != null && t.BaseType.IsGenericType && serviceType.IsAssignableFrom(t.BaseType.GetGenericTypeDefinition())) ||
                             i.IsGenericType && serviceType.IsAssignableFrom(i.GetGenericTypeDefinition())
                             select t;

                _container.RegisterMultiple(serviceType, result).AsMultiInstance();
            }
            else
            {
                var list = GetTypes().Where(t => serviceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsInterface);
                _container.RegisterMultiple(serviceType, list);
            }
        }

        /// <summary> 
        /// </summary> 
        public static TServiceType Resolve<TServiceType>()
            where TServiceType : class
        {
            return _container.Resolve<TServiceType>();
        }

        /// <summary> 
        /// </summary> 
        public static IEnumerable<TServiceType> ResolveAll<TServiceType>()
            where TServiceType : class
        {
            return _container.ResolveAll<TServiceType>();
        }

        /// <summary>
        /// </summary> 
        public static IEnumerable<Object> ResolveAll(Type ServiceType)
        {
            return _container.ResolveAll(ServiceType);
        }

        private static IEnumerable<Type> GetTypes()
        {
            var types1 = Assembly.GetExecutingAssembly().GetTypes().ToArray();
            var types2 = Assembly.GetEntryAssembly().GetTypes();
            return types1.Concat(types2);
        }
    }
}
