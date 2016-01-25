namespace Demo.DbContextMocking
{
	public interface IContextFactory
	{
		IFooContext Create();
	}
}