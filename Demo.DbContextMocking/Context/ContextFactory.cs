using Demo.DbContextMocking.Models;

namespace Demo.DbContextMocking
{
	public class ContextFactory : IContextFactory
	{
		public IFooContext Create()
		{
			return new FooContext();
		} 
	}
}