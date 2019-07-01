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

        public static void RegisterTypes<TServiceType>() where TServiceType : class
        {
            var list = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(TServiceType).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsInterface);
            _container.RegisterMultiple(typeof(TServiceType), list);
        }

        public static void RegisterTypes(Type serviceType)
        {
            var list = Assembly.GetExecutingAssembly().GetTypes().Where(t => serviceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && !t.IsInterface);
            _container.RegisterMultiple(serviceType, list);
        }

        /// <summary>
        ///  反转
        /// </summary> 
        public static TServiceType Resolve<TServiceType>(string name = null)
            where TServiceType : class
        {
            return _container.Resolve<TServiceType>(name);
        }

        /// <summary>
        ///  反转
        /// </summary> 
        public static IEnumerable<TServiceType> ResolveAll<TServiceType>()
            where TServiceType : class
        {
            return _container.ResolveAll<TServiceType>();
        }
    }
}
