using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NUnit.Framework;

namespace Demo.DbContextMocking.IsolatedTests
{
    public class MockTests
    {
		[Test]
		public void RealRepository_WhenCalled_ReturnsMockData()
		{
			var kernel = new StandardKernel();
			kernel.Load<AppModule>();
			kernel.Load<MockModule>(); //order is important. In MockModule we rebind IContextFactory

			var repo = kernel.Get<ReportRepository>();

			var reports = repo.GetReports();

			Assert.IsEmpty(reports);
		}
	}
}
