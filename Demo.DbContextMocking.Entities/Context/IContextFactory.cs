namespace Demo.DbContextMocking.Entities
{
	public interface IContextFactory
	{
		IFooContext Create();
	}
}