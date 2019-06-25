using TinyIoC;

namespace CSMP.Agent.Dependency
{
	public static class DependencyService
	{
		private static readonly TinyIoCContainer _container = TinyIoCContainer.Current;

		public static void Register<TServiceType>() where TServiceType : class
		{
			_container.Register<TServiceType>();
		}

		public static void Register<TServiceType, TImplementationType>()
			where TServiceType : class
			where TImplementationType : class, TServiceType
		{
			_container.Register<TServiceType, TImplementationType>();
		}


		public static void Resolve<TServiceType>()
			where TServiceType : class
		{
			_container.Resolve<TServiceType>();
		}
	}
}
