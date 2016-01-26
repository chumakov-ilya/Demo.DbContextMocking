using Ninject.Modules;

namespace Demo.DbContextMocking
{
	public class AppModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IContextFactory>().To<ContextFactory>();
		}
	}
}