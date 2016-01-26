using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Demo.DbContextMocking.Models;
using Moq;

namespace Demo.DbContextMocking.IsolatedTests
{
	public class MockContextFactory : IContextFactory
	{
		public IFooContext Create()
		{
			var mockRepository = new MockRepository(MockBehavior.Loose) { DefaultValue = DefaultValue.Mock };

			var mockContext = mockRepository.Create<IFooContext>();

			mockContext.Setup(x => x.SaveChanges())
				.Returns(int.MaxValue);

			List<Report> mockReports = MockReports();

			var mockDbSet = MockDbSet<Report>(mockReports);

			mockContext.Setup(m => m.Reports).Returns(mockDbSet.Object);

			return mockContext.Object;
		}

		private List<Report> MockReports()
		{
			List<Report> mockReports = new List<Report>();

			mockReports.Add(new Report {Id = 1, Name = "Mock Report #1"});

			return mockReports;
		}

		private Mock<DbSet<T>> MockDbSet<T>(List<T> data = null) where T : class
		{
			if (data == null) data = new List<T>();

			var queryable = data.AsQueryable();

			var mock = new Mock<DbSet<T>>();

			mock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
			mock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
			mock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
			mock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

			return mock;
		}
	}
}