using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Demo.DbContextMocking.Models;
using Moq;
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

	public class MockContextFactory : IContextFactory
	{
		public IFooContext Create()
		{
			var mockRepository = new MockRepository(MockBehavior.Loose) { DefaultValue = DefaultValue.Mock };

			var mockContext = mockRepository.Create<IFooContext>();

			mockContext.Setup(x => x.SaveChanges())
				.Returns(int.MaxValue);

			var mockDbSet = MockDbSet<Report>();

			mockContext.Setup(m => m.Reports).Returns(mockDbSet.Object);

			return mockContext.Object;
		}

		private static Mock<DbSet<T>> MockDbSet<T>() where T : class
		{
			var data = new List<T>().AsQueryable();

			var mock = new Mock<DbSet<T>>();

			mock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
			mock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
			mock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
			mock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

			return mock;
		}

	}
}