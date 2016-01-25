using Ninject.Modules;

namespace Demo.DbContextMocking.IsolatedTests
{
	public class MockModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IContextFactory>().To<MockContextFactory>();
		}
	}

	public class MockContextFactory : IContextFactory
	{
		public IFooContext Create()
		{
			throw new System.NotImplementedException();
		}
	}
}