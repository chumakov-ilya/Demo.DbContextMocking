using Ninject.Modules;

namespace Demo.DbContextMocking.IsolatedTests
{
	public class MockModule : NinjectModule
	{
		public override void Load()
		{
			Rebind<IContextFactory>().To<MockContextFactory>();
		}
	}
}