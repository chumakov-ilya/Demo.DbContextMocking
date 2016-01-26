using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DbContextMocking.Entities;
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
			//Order is important. In MockModule we rebind IContextFactory.
			//Another option is to load MockModule only.
			kernel.Load<MockModule>(); 

			var repo = kernel.Get<ReportRepository>();

			var reports = repo.GetReports();

			Assert.IsNotEmpty(reports);
		}
	}
}
