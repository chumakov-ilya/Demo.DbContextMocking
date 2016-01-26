using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.DbContextMocking.Entities
{
	public interface IFooContext : IDisposable
	{
		IDbSet<Report> Reports { get; set; }
		int SaveChanges();
		Task<int> SaveChangesAsync();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}