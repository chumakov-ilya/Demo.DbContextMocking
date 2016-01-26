using Demo.DbContextMocking.Entities;
using Ninject;
using NUnit.Framework;

namespace Demo.DbContextMocking.IntegrationTests
{
	public class DbTests
	{
		[Test]
		public void RealRepository_WhenCalled_ReturnsEmpty()
		{
			var kernel = new StandardKernel();
			kernel.Load<AppModule>();

			var repo = kernel.Get<ReportRepository>();

			var reports = repo.GetReports();

			Assert.IsEmpty(reports);
		}
	}
}
