namespace Demo.DbContextMocking.Entities
{
	public class ContextFactory : IContextFactory
	{
		public IFooContext Create()
		{
			return new FooContext();
		} 
	}
}